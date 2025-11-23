using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : OnAttackedStatus
{
    public override bool Positive => false;

    protected override void OnAttackedAction(Attack attack)
    {
        attack.ChangeDammage(+Amount);
        UpdateStatusInTarget(-1);
    }

    public override string GetDescription()
    {
        return $"The next attack I receive will deal {Amount.ColorizeStatusString(true)} more damage. Lose all stack when attacked";
    }
}
