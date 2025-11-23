using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : OnStartTurnStatus
{
    public override StatusEffect StatusEnum => StatusEffect.Regen;
    protected override void OnStartTurnAction(FightingInstance target)
    {
        target.Heal(Amount);
        base.OnStartTurnAction(target);
    }

    public override string GetDescription()
    {
        return $"At the start of the turn, Heal {Amount.ColorizeStatusString()} hp and lose 1 stack";
    }
}
