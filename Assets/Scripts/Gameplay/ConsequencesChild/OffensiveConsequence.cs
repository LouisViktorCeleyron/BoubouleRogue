using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consequence", menuName = "MyStuffs/Consequences/Offensive")]
public class OffensiveConsequence : StatusOnlyConsequence
{
    public ElementalType type = ElementalType.Neutral;
    public int baseDamages, recoilDamages = 0;

    protected override void ConsequenceAction()
    {
        var attack = new Attack(baseDamages, type, _target);
        _target.ReceiveAttack(attack);
        if( recoilDamages > 0 ) 
        {
            _launcher.AutoInflictedDamage(recoilDamages);
        }
        base.ConsequenceAction();
    }
}

