using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Consequence", menuName = "MyStuffs/Consequences/Factory")]
public class FactoryConsequence : Consequence
{
    public Element element;
    protected override void ConsequenceAction()
    {
        var f = _target.GetStatus<Factory>();
        if(f== null)
        {
            f=_target.AddStatus<Factory>(1);
        }
        f.element = element;
    }
    public override string GetDescription(FightingInstance launcher = null)
    {
        
     return $"Add 1 new {element.GetColoredElementName()} to your hand every turn. Replace old Factory";   
    }
}
