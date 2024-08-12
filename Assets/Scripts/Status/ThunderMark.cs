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

}
