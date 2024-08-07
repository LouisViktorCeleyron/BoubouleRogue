using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightingInstance : MonoBehaviour
{
    [SerializeField]
    protected int _hpMax = 30;
    [SerializeField]
    protected int _currentHp = 30;

    public List<Status> statusEffects;


    public MyDelegate<Attack> OnAttackReceived;
    public MyDelegate<Status> OnStatusInflicted;
    public MyDelegate<FightingInstance> OnStartTurn, OnEndTurn;
    
    
    [Header("Feedbacks")]
    public UnityEvent<int,int> OnHpChanged;
    public UnityEvent<StatusEffect,int> OnStatusInflictedFeedback;
    
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

        _battleManager = ManagerManager.GetManager<BattleManager>();
    }


    public void StartTurn()
    {
        OnStartTurn.Launch(this);
    }
    public void EndTurn()
    {
        OnEndTurn.Launch(this);
    }
    public int GetHp() 
    { 
        return _currentHp;
    }
    public void ReceiveAttack(Attack  attack)
    {
        OnAttackReceived.Launch(attack);
        SetHp(_currentHp - attack.GetDammage());
    }
    public void AutoInflictedDamage(int amount)
    {
        SetHp(_currentHp - amount, true);

    }
    public void Heal(int amount) 
    { 
        SetHp(_currentHp + amount, false);
    }
    public void SetHp(int newAmount, bool negativeFeedback = true)
    {
        _currentHp = Mathf.Clamp(newAmount,0,_hpMax);
        OnHpChanged.Invoke(_currentHp,_hpMax);
        SetHpMoreFeedback();
        if(_currentHp<=0)
        {
            EndOfBattle();
        }
    }
    public virtual void SetHpMoreFeedback()
    {

    }
    public virtual void EndOfBattle()
    {

    }

    public void AddStatus<T>(int amount) where T : Status, new()
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
        OnStatusInflictedFeedback.Invoke(currentStatus.StatusEnum, currentStatus.GetAmount());
        
        if (currentStatus.GetAmount() <= 0)
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
    }
    public void AddStatusNonGeneric(System.Type type, int amount)
    {
        MethodInfo method = GetType().GetMethod("AddStatus");
        method = method.MakeGenericMethod(type);
        method.Invoke(this, new object[] { amount });
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
