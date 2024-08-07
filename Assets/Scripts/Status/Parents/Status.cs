using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status
{
    protected FightingInstance _target;
    [SerializeField]
    protected int _amount;
    public virtual StatusEffect StatusEnum
    {
        get
        {
            Enum.TryParse<StatusEffect>(GetType().ToString(), out var ret);
            return ret;
        }
    }

    public virtual bool Positive => true;

    public void Inflict(FightingInstance target, int amount)
    {
        _target = target;
        _amount = amount;
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
        _amount = Mathf.Clamp(0, _amount+toAddOrRemove, 999);
        if (_amount <= 0)
        {
            Unsubscribe();
        }
    }

    public int GetAmount()
    {
        return _amount;
    }
    protected virtual void Subscribe()
    {

    }

    protected virtual void Unsubscribe()
    {

    }

}
