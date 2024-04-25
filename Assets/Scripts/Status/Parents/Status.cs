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
    public void Inflict(FightingInstance target, int amount)
    {
        _target = target;
        _amount = amount;
        Subscribe();
    }
    protected void UpdateStatusInPlayer(int amount) 
    {
        _target.UpdateStatus(amount, StatusEnum);
    }
    public void ChangeAmount(int toAddOrRemove)
    {
        _amount = Mathf.Clamp(0, _amount+toAddOrRemove, 999);
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
