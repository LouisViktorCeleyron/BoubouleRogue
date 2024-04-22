using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : OnAttackedStatus
{
    protected override void OnAttackedAction(Attack attack)
    {
        attack.ChangeDammage(-_amount);
    }
}
