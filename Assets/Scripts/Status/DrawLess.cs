using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLess : OnStartTurnStatus
{
    public override StatusEffect StatusEnum => StatusEffect.DrawLess;
    public override bool Positive => false;

    protected override void OnStartTurnAction(FightingInstance target)
    {
        
    }

    public override string GetDescription()
    {
        return $"Draw {Amount.ColorizeStatusString(true)} less elements next turn";  
    }
}
