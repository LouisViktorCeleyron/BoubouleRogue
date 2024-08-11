using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tough : Status
{

    public override StatusEffect StatusEnum => StatusEffect.Tough;

    protected override void Subscribe()
    {
        _target.Stats.AddStrength(1);
        base.Subscribe();
    }

    protected override void Unsubscribe()
    {
        _target.Stats.AddStrength(-1);
        base.Unsubscribe();
    }
}
