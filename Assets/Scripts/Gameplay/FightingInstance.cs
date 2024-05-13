using System.Collections;
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
    public MyDelegate<FightingInstance> OnStartTurn;
    
    public UnityEvent<float> OnHpChanged;
    public UnityEvent<StatusEffect,int> OnStatusInflicted;
    
    protected BattleManager _battleManager;

    private void Awake()
    {
        //init
        OnAttackReceived = new MyDelegate<Attack>();
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
        OnStartTurn.Launch(this);
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

    public void UpdateStatus(int amount, StatusEffect effect)
    {
        switch(effect) 
        {
            case StatusEffect.Shield:
                AddStatus<Shield>(amount);
                break;

            case StatusEffect.Burn:
                AddStatus<Burn>(amount);
                break;
        }
    }
}
