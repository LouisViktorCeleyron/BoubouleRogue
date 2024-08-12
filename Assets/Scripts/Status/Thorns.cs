using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : OnAttackedStatus
{
    public override StatusEffect StatusEnum => StatusEffect.Thorns;
    protected override void OnAttackedAction(Attack attack)
    {
        attack.GetLauncher().AutoInflictedDamage(Amount);
        UpdateStatusInTarget(-1);
    }
}
