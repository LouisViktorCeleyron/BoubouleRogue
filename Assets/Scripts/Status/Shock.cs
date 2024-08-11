using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shock : OnStatusStatus
{
    public override StatusEffect StatusEnum => StatusEffect.Shock;
    public override bool Positive => true;
    protected override void OnStatusInflictedAction(Status statusInflicted)
    {
        if(statusInflicted.StatusEnum == StatusEffect.Shield)
        {
            statusInflicted.UpdateStatusInTarget(-_amount);
        }
    }

    private void ReduceStack(FightingInstance fi)
    {
        UpdateStatusInTarget(-1);
    }
    protected override void Subscribe()
    {
        base.Subscribe();
        _target.OnEndTurn.Subscribe(ReduceStack);
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();
        _target.OnEndTurn.Unsubscribe(ReduceStack);
    }
}
