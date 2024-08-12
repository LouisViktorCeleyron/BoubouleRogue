using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tough : Status
{

    public override StatusEffect StatusEnum => StatusEffect.Tough;

    protected override void OnAmountChange(int amountChanged)
    {
        _target.Stats.AddStrength(amountChanged);
    }

}
