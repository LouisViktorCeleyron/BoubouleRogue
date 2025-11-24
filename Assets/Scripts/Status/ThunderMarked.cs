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

    public override string GetDescription()
    {
        return $"At the end of my turn i'll lose 1 stack and gain {("1 Thunder Mark").ColorizeStatusString()}. When stack reach 0 ThunderMark will be released";
    }

}
