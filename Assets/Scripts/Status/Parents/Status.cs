using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status
{
    protected FightingInstance _target;
    public virtual string Name => StatusEnum.ToString();

    [SerializeField]
    private int _amount;
    public int Amount => _amount;
    [SerializeField]
    private string _name;
    public virtual StatusEffect StatusEnum
    {
        get
        {
            Enum.TryParse<StatusEffect>(GetType().ToString(), out var ret);
            return ret;
        }
    }

    public virtual bool Positive => true;
    /// <summary>
    /// Launched on Start and/or on admition
    /// </summary>
    public virtual void StartStatus()
    {

    }
    public void Inflict(FightingInstance target, int amount)
    {
        _name = GetType().Name;
        _target = target;
        StartStatus();
        ChangeAmount(amount);
        Subscribe();
    }
    /// <summary>
    /// Change Status amount for the target fighting Instance with feedback
    /// </summary>
    /// <param name="amount"></param>
    public void UpdateStatusInTarget(int amount) 
    {
        _target.UpdateStatus(amount, StatusEnum);
        
    }
    /// <summary>
    /// Change only amount whithout any feedback. For the feedback version pleas use UpdateStatusInTarget
    /// </summary>
    /// <param name="toAddOrRemove"></param>
    public void ChangeAmount(int toAddOrRemove)
    {
        BeforeAmountChange(ref toAddOrRemove);
        var addedOrRemoved = Mathf.Clamp(toAddOrRemove, -_amount, 999);
        _amount += addedOrRemoved;
        OnAmountChange(addedOrRemoved);
        if (_amount <= 0)
        {
            Unsubscribe();
        }
    }
    protected virtual void BeforeAmountChange(ref int amountChanged)
    {

    }   
    protected virtual void OnAmountChange(int amountChanged)
    {

    }

    protected virtual void Subscribe()
    {

    }

    protected virtual void Unsubscribe()
    {

    }

    public virtual string GetDescription()
    {
        return "Status will do stuff when stuff";
    }
}
