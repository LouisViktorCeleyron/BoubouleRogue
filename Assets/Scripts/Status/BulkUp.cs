using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulkUp : OnStatusStatus
{
    public override StatusEffect StatusEnum => base.StatusEnum;
    protected override void OnStatusInflictedAction(Status statusInflicted)
    {
        if(statusInflicted.StatusEnum == StatusEffect.Shield)
        {
            statusInflicted.UpdateStatusInTarget(_amount);
        }
    }

    private void ReduceStack(FightingInstance fi)
    {
        UpdateStatusInTarget(-1);
    }
    protected override void Subscribe()
    {
        base.Subscribe();
        _target.OnStartTurn.Subscribe(ReduceStack);
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();
        _target.OnStartTurn.Unsubscribe(ReduceStack);
    }
}
