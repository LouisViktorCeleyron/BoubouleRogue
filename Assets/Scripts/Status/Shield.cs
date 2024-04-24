using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shield : OnAttackedStatus
{

    protected override void OnAttackedAction(Attack attack)
    {
        Debug.Log("attack changed");
        attack.ChangeDammage(-_amount);
    }
}
