using LCStarterContent.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatchaMaster : ScriptableObject
{
    public List<Element> commonElements;
    public List<Element> rareElements;
    public List<Element> legendaryElements;


    public WeightedList<Element> GetElementsForGatcha()
    {
        var ret = new WeightedList<Element>();

        ret.Add(commonElements.GetRandomElement(), 6);
        ret.Add(rareElements.GetRandomElement(), 3);
        ret.Add(legendaryElements.GetRandomElement(), 1);

        return ret;
    }
    
}
