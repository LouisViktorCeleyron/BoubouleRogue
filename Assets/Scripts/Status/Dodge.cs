using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : OnAttackedStatus
{
    public override StatusEffect StatusEnum => StatusEffect.Dodge;
    protected override void OnAttackedAction(Attack attack)
    {
        var generatedDodge = Random.Range(0, 11);
        if(generatedDodge <= _amount)
        {
            attack.ChangeDammage(-999);
            UpdateStatusInTarget(-999);
        }
    }
}
