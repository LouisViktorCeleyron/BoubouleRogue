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
            status.ApplyStatus(_target);
        }
    }
}

[System.Serializable]
public struct StatusInflicted
{
    public int amount;
    public StatusEffect effect;

    public void ApplyStatus(FightingInstance target)
    {
       target.UpdateStatus(amount, effect);
    }
}