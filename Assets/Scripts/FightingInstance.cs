using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightingInstance : MonoBehaviour
{
    public int hpMax;
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
}
