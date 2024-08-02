using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Veil : OnStatusStatus
{
    public override StatusEffect StatusEnum => StatusEffect.Veil;
    protected override void OnStatusInflictedAction(Status statusInflicted)
    {
        if(!statusInflicted.Positive) 
        { 
            statusInflicted.UpdateStatusInTarget(-999);
            UpdateStatusInTarget(-1);
        }
    }
}
