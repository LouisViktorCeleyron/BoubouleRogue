using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : OnAttackedStatus
{
    public override StatusEffect StatusEnum => StatusEffect.Dodge;
    protected override void OnAttackedAction(Attack attack)
    {
        var generatedDodge = Random.Range(0, 11);
        if(generatedDodge <= Amount)
        {
            attack.ChangeDamage(-999);
            UpdateStatusInTarget(-999);
        }
    }

    public override string GetDescription()
    {
        var amountText = $"{Amount * 10}% chances".ColorizeStatusString();
        return $"{amountText} to avoid all damage and lose all {"Dodge stacks".ColorizeStatusString()}.";
    }
}
