using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ShopStuff",menuName ="MyStuffs/ShopStuff")]
public class PotentialShopItem : ScriptableObject
{
    public WeightedList<Element> buyableStuff;
    public Element GetBuyableStuff()
    {
        return buyableStuff.GetRandomElement();
    }
}
