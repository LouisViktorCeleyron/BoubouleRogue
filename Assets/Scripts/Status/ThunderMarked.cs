using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderMarked : OnEndTurnStatus
{
    public override StatusEffect StatusEnum => StatusEffect.ThunderMarked;
    public override bool Positive => false;
    protected override void OnEndTurnAction(FightingInstance target)
    {
        _target.AddStatus<ThunderMark>(1);
    }

    protected override void Unsubscribe()
    {
        _target.GetStatus<ThunderMark>().Release();
        base.Unsubscribe();
    }

}
