using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulkUp : OnStatusStatus
{
    public override StatusEffect StatusEnum => base.StatusEnum;
    protected override void OnStatusInflictedAction(Status statusInflicted)
    {
        base.OnStatusInflictedAction(statusInflicted);
    }


}
