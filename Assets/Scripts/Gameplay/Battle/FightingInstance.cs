using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightingInstance : MonoBehaviour
{
    [SerializeField]
    protected FIStats _stats;
    public FIStats Stats => _stats;

    public List<Status> statusEffects;


    public MyDelegate<Attack> OnAttackReceived;
    public MyDelegate<Status> OnStatusInflicted;
    public MyDelegate<FightingInstance> OnStartTurn, OnEndTurn;
    
    
    [Header("Feedbacks")]
    public UnityEvent<int,int> OnHpChanged;
    public UnityEvent<Status> OnStatusInflictedFeedback;
    
    protected BattleManager _battleManager;
    public FightingInstanceFeedbackSubComponent feedbackSubComp;
    private bool _lockAntiStack;


    private void Awake()
    {
        //init
        OnAttackReceived = new MyDelegate<Attack>();
        OnStartTurn = new MyDelegate<FightingInstance>();
        OnEndTurn = new MyDelegate<FightingInstance>();
        OnStatusInflicted = new MyDelegate<Status>();
        statusEffects = new List<Status>();
        feedbackSubComp.Init(this);

        _stats = new FIStats(this);

        _battleManager = ManagerManager.GetManager<BattleManager>();
    }

    public virtual void SetHpMoreFeedback()
    {

    }

    public void StartTurn()
    {
        OnStartTurn.Launch(this);
        foreach (var s in statusEffects)
        {
            s.StartStatus();
        }
    }
    public void EndTurn()
    {
        OnEndTurn.Launch(this);
    }

    public void ReceiveAttack(Attack attack, UnityAction<int> onAtkTaken = null)
    {
        OnAttackReceived.Launch(attack);
        _stats.AddHp(- attack.GetDammage());
        if(onAtkTaken != null) 
        {
            onAtkTaken.Invoke(attack.GetDammage());
        }
    }
    public void AutoInflictedDamage(int amount)
    {
        _stats.AddHp (- amount, true);

    }
    public void Heal(int amount)
    { 
        _stats.AddHp( amount, false);
    }
 
    public virtual void EndOfBattle()
    {

    }

    public T AddStatus<T>(int amount) where T : Status, new()
    {
        var currentStatus = statusEffects.Find((Status s) => s.GetType() == typeof(T));
        if (currentStatus != null)
        {
            currentStatus.ChangeAmount(amount);
        }
        else
        {
            currentStatus = new T();
            currentStatus.Inflict(this,amount);
            statusEffects.Add(currentStatus);
        }
        OnStatusInflictedFeedback.Invoke(currentStatus);
        
        if (currentStatus.Amount <= 0)
        {
            statusEffects.Remove(currentStatus);
        }
        else
        {
            if(_lockAntiStack == false)
            {
                _lockAntiStack = true;
                OnStatusInflicted.Launch(currentStatus);
                _lockAntiStack = false;
            }
        }
        return currentStatus as T;
    }
    public void AddStatusNonGeneric(System.Type type, int amount)
    {
        MethodInfo method = GetType().GetMethod("AddStatus");
        method = method.MakeGenericMethod(type);
        method.Invoke(this, new object[] { amount });
    }
  
    public void UpdateStatus(StatusInflicted s)
    {
        UpdateStatus(s.amount, s.effect);
    }
    public void UpdateStatus(int amount, StatusEffect effect)
    {
        var type = System.Type.GetType(effect.ToString());
        if(type == null)
        {
            return;
        }
        AddStatusNonGeneric(type, amount);
    }

    public T GetStatus<T>() where T : Status
    {
        return statusEffects.Find((Status s)=> s.GetType()== typeof(T)) as T;
    }
}
