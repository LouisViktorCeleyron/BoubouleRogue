using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Manager
{
    public int hpMax, currentHp;

    [SerializeField]
    private List<Element> _deck;
    public List<Element> Deck => _deck;
    public int currentGold;
    public override void ManagerPreAwake()
    {
        base.ManagerPreAwake();
    }

    public void ClearDeck()
    {
        _deck = new List<Element>();
    }

    public void AddElementToDeck(Element element, int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            _deck.Add(element);
        }
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
        //add feedback
    }
}
