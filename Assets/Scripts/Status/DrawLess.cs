using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLess : OnStartTurnStatus
{
    public override StatusEffect StatusEnum => StatusEffect.DrawLess;
    protected override void OnStartTurnAction(FightingInstance target)
    {
        
    }
}
