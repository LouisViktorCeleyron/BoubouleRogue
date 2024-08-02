using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : OnStartTurnStatus
{
    public override StatusEffect StatusEnum => StatusEffect.Regen;
    protected override void OnStartTurnAction(FightingInstance target)
    {
        target.Heal(_amount);
        base.OnStartTurnAction(target);
    }
}
