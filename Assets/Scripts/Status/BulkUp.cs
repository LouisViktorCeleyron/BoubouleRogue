using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulkUp : OnStartTurnStatus
{
    public override StatusEffect StatusEnum => base.StatusEnum;

    protected override void OnAmountChange(int amountChanged)
    {
        "Amount Changed".ColorDebugLog();
        _target.Stats.AddBulk(amountChanged);
    }

}
