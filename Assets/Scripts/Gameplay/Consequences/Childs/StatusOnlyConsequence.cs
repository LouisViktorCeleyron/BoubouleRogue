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

    public override string GetDescription()
    {
        var retStatus = string.Empty;
        foreach (var status in statusToInflict)
        {
            retStatus += $"{status.amount.ColorizeString(ColorizeExtention.StatsColor)} {status.effect}. ";
        }
        var retBase = base.GetDescription();

        return retStatus + retBase;
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
       target.UpdateStatus(amount, effect);
    }
}