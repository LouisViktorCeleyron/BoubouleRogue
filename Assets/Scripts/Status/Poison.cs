using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : OnStartTurnStatus
{
    public override StatusEffect StatusEnum => StatusEffect.Poison;
    public override bool Positive => false;
    protected override void OnStartTurnAction(FightingInstance target)
    {
        target.AutoInflictedDamage(Amount);
    }
}
