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
    }

    public void AddStatus<T>(int amount) where T : Status, new()
    {
        var currentStatus = statusEffects.Find((Status s)=> s.GetType() == typeof(T));
        if(currentStatus != null) 
        {
            currentStatus.ChangeAmount(amount);
        }
        else
        {
            var _tempStatus = new T();
            _tempStatus.ChangeAmount(amount);
            statusEffects.Add(_tempStatus);
        }
    }
}
