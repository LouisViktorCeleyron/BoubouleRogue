using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Status 
{
    protected FightingInstance _target;
    protected int _amount;

    public void Inflict(FightingInstance target, int amount)
    {
        _target = target;
        _amount = amount;
        Subscribe();
    }

    public void ChangeAmount(int toAddOrRemove)
    {
        _amount = Mathf.Clamp(0, _amount+toAddOrRemove, 999);
    }
    protected virtual void Subscribe()
    {

    }

    protected virtual void Unsubscribe()
    {

    }
}
