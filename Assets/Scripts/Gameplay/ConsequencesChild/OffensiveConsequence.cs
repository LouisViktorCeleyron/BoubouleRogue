using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consequence", menuName = "MyStuffs/Consequences/Offensive")]
public class OffensiveConsequence : StatusOnlyConsequence
{
    public ElementalType type = ElementalType.Neutral;
    public int baseDammage;

    protected override void ConsequenceAction()
    {
        var attack = new Attack(baseDammage, type, _target);
        _target.ReceiveAttack(attack);
        base.ConsequenceAction();
    }
}

