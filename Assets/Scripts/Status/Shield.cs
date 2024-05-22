using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shield : OnAttackedStatus
{

    protected override void OnAttackedAction(Attack attack)
    {
        var tempDamage = attack.GetDammage();
        attack.ChangeDammage(-_amount);
        UpdateStatusInPlayer(-tempDamage);
    }

    protected override void Subscribe()
    {
        base.Subscribe();
        _target.OnStartTurn.Subscribe(ResetShield);
    }

    private void ResetShield(FightingInstance target)
    {
        UpdateStatusInPlayer(-999);
    }
}
