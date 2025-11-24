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

    public override string GetDescription()
    {
        return $"When I'm attacked, I do {Amount.ColorizeStatusString()} damages, then lose 1 stack";
    }
}
