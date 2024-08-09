using LCStarterContent.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Gatcha Master", menuName ="MyStuffs/GatchaMaster")]
public class GatchaMaster : ScriptableObject
{
    public List<Element> commonElements;
    public List<Element> rareElements;
    public List<Element> legendaryElements;


    public WeightedList<Element> GetElementsForGatcha()
    {
        var ret = new WeightedList<Element>();
        var c = commonElements.GetRandomElement();
        ret.Add(c, 6f);
        ret.Add(rareElements.GetRandomElement(), 3f);
        ret.Add(legendaryElements.GetRandomElement(), 1f);

        return ret;
    }
    
}
