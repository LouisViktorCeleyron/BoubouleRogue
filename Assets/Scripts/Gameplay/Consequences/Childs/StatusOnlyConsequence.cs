using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consequence", menuName = "MyStuffs/Consequences/StatusOnlyConsequence")]
public class StatusOnlyConsequence : Consequence
{
    [SerializeField]
    private List<StatusInflicted> statusToInflict;
    protected override void ConsequenceAction()
    {
        foreach (var status in statusToInflict) 
        {
            var targetForStatus = status.inverseTarget ? _otherTarget : _target;
            status.ApplyStatus(targetForStatus);
        }
    }

    public override string GetDescription(FightingInstance launcher = null)
    {
        var retStatus = string.Empty;
        var retInverseTarget = string.Empty;
        foreach (var status in statusToInflict)
        {
            var amountShieldTEMP = status.effect == StatusEffect.Shield && launcher!= null? launcher.Stats.Bulk : 0;
            var currentRetStatus = $"{(status.amount + amountShieldTEMP).ColorizeString(ColorizeExtention.StatsColor)} {status.effect}";
            if(status.inverseTarget)
            {
                var retTargetTarget = !selfInflicted ? "self" : "oponent";
                retInverseTarget += $"{currentRetStatus}, to {retTargetTarget}.";
            }
            else
            {
                retStatus += currentRetStatus+". ";
            }
        }
        var retBase = base.GetDescription(launcher);

        return retStatus + retBase + retInverseTarget;
    }
}

[System.Serializable]
public struct StatusInflicted
{
    public int amount;
    public StatusEffect effect;
    public bool inverseTarget;

    //En fait il faudrait que je fasse un tableau des consequences avec leur Icones et leur couleur jsp si c'est possible enfin si avec des scriptable quoi 

    public void ApplyStatus(FightingInstance target)
    {
       target.UpdateStatus(this);
    }
}