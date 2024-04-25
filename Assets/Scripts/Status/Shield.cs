using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shield : OnAttackedStatus
{

    protected override void OnAttackedAction(Attack attack)
    {
        "Shielded".ColorDebugLog(Color.cyan);
        var tempDamage = attack.GetDammage();
        attack.ChangeDammage(-_amount);
        UpdateStatusInPlayer(-tempDamage);
    }
}
