using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderMarked : OnStartTurnStatus
{
    public override StatusEffect StatusEnum => StatusEffect.ThunderMark;
    public override bool Positive => false;

    protected override void OnStartTurnAction(FightingInstance target)
    {
        _target.AddStatus<ThunderMark>(1);
    }

    protected override void Unsubscribe()
    {
        _target.GetStatus<ThunderMark>().Release();
    }

}
