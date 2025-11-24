using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderMark : Status
{
    public override StatusEffect StatusEnum => StatusEffect.ThunderMark;
    public override bool Positive => false;


    public void Release()
    {
        var constManager = ManagerManager.GetManager<ConstManager>();
        _target.AutoInflictedDamage(Amount * constManager.baseThunderMarkDamage);
        UpdateStatusInTarget(-999);
    }

    public override string GetDescription()
    {
        return $"When released, lose all stack and I'll receive {"The same amount".ColorizeStatusString(true)} in damage";
    }

}
