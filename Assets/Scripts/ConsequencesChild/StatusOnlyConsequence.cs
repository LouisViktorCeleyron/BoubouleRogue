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
        switch (effect)
        {
            case StatusEffect.shield:
                target.AddStatus<Shield>(amount);
                break;
            case StatusEffect.poison:
                break;
            default:
                break;
        }
    }
}