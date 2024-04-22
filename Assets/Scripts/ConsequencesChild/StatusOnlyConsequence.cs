using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consequence", menuName = "MyStuffs/Consequences/StatusOnlyConsequence")]
public class StatusOnlyConsequence : Consequence
{
    public int amount;
    public bool shield, poison, burn, drowned;

    protected override void ConsequenceAction()
    {

    }
}
