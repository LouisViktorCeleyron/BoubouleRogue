using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    //Faut que je crée un scriptable object de modification, de test etou
    public PotentialShopItem potentialShopItem;
    public List<BuyableElement> shopElements;


    void Start()
    {
        foreach (var se in shopElements)
        {
            var element = potentialShopItem.GetBuyableStuff();
            se.SetupUI(element);
        }
    }

}
