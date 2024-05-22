using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : OnStartTurnStatus
{
    public override StatusEffect StatusEnum => StatusEffect.Poison;

    protected override void OnStartTurnAction(FightingInstance target)
    {
        target.AutoInflictedDamage(_amount);
        UpdateStatusInPlayer(-1);
    }
}
