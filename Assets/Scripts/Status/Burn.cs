using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : OnAttackedStatus
{
    protected override void OnAttackedAction(Attack attack)
    {
        attack.ChangeDammage(+_amount);
        _target.UpdateStatus(-1,StatusEnum);
    }
}
