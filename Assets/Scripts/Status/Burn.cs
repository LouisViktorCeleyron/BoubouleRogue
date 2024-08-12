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
}
