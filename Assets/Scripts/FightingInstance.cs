using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightingInstance : MonoBehaviour
{
    public int hpMax;
    [SerializeField]
    private int _currentHp;

    public List<Status> statusEffects;

    
    public MyDelegate<Attack> OnAttackReceived;
    public UnityEvent<float> OnHpChanged;
    public UnityEvent<StatusEffect,int> OnStatusInflicted;


    private void Awake()
    {
        //init
        OnAttackReceived = new MyDelegate<Attack>();
    }

    void Start()
    {
        statusEffects = new List<Status>();
        SetHp(hpMax);
    }

    public void ReceiveAttack(Attack  attack)
    {
        OnAttackReceived.Launch(attack);
        SetHp(_currentHp - attack.GetDammage());
    }

    private void SetHp(int newAmount, bool negativeFeedback = true)
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
            var _tempStatus = new T();
            _tempStatus.Inflict(this,amount);
            statusEffects.Add(_tempStatus);
        }
    }

    public void UpdateStatus(int amount, StatusEffect effect)
    {
        switch(effect) 
        {
            case StatusEffect.shield:
                AddStatus<Shield>(amount);
                break;

            case StatusEffect.poison:
                //AddStatus<>(amount);
                break;
        }
        OnStatusInflicted.Invoke(effect, amount);
    }
}
