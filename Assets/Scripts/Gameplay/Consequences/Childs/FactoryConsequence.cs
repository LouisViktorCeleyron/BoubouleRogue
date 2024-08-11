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
            _target.AddStatus<Factory>(1);
        }
        f.element = element;
    }
    public override string GetDescription()
    {
        
     return $"Add 1 new {element.GetColoredElementName()} to your hand every turn. They're available until the end of the battle. Only 1 Factory can be active. The new one will replace the active one.";   
    }
}
