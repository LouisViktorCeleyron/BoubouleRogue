using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shield : OnAttackedStatus
{

    protected override void OnAttackedAction(Attack attack)
    {
        var tempDamage = attack.GetDammage();
        attack.ChangeDammage(-Amount);
        UpdateStatusInTarget(-tempDamage);
    }

    protected override void BeforeAmountChange(ref int amountChanged)
    {
        if(amountChanged > 0)
        {
            amountChanged += _target.Stats.Bulk;
        }
    }
    protected override void Subscribe()
    {
        base.Subscribe();
        _target.OnStartTurn.Subscribe(ResetShield);
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();
        _target.OnStartTurn.Unsubscribe(ResetShield);
    }

    private void ResetShield(FightingInstance target)
    {
        UpdateStatusInTarget(-999);
    }

    public override string GetDescription()
    {
        var amount = $"{Amount}".ColorizeStatusString();

        return $"Prevent up to {amount} damage. Remove all stack at the start of the user's turn";
    }
}
