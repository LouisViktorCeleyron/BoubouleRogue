using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightingInstance : MonoBehaviour
{
    public int hpMax;
    [SerializeField]
    protected int _currentHp;

    public List<Status> statusEffects;

    public bool isPlayer;

    public MyDelegate<Attack> OnAttackReceived;
    public MyDelegate<FightingInstance> OnStartTurn, OnEndTurn;
    
    public UnityEvent<float> OnHpChanged;
    public UnityEvent<StatusEffect,int> OnStatusInflicted;
    
    protected BattleManager _battleManager;
    public FightingInstanceFeedbackSubComponent feedbackSubComp;

    private void Awake()
    {
        //init
        OnAttackReceived = new MyDelegate<Attack>();
        OnStartTurn = new MyDelegate<FightingInstance>();
        OnEndTurn = new MyDelegate<FightingInstance>();
        statusEffects = new List<Status>();

        _battleManager = ManagerManager.GetManager<BattleManager>();
    }

    private void Start()
    {
        if (isPlayer)
        {
            _battleManager.playerInstance = this;
        }
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
    public void SetHp(int newAmount, bool negativeFeedback = true)
    {
        _currentHp = newAmount;
        OnHpChanged.Invoke((float)_currentHp / (float)hpMax);
        if(_currentHp<=0)
        {
            _battleManager.EndOfBattle(isPlayer);
        }
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
        OnStatusInflicted.Invoke(currentStatus.StatusEnum, currentStatus.GetAmount());
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
