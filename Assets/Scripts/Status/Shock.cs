using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shock : OnEndTurnStatus
{
    public override StatusEffect StatusEnum => StatusEffect.Shock;
    public override bool Positive => false;

    protected override void OnAmountChange(int amountChanged)
    {
        _target.Stats.AddBulk(-amountChanged);

    }


}
