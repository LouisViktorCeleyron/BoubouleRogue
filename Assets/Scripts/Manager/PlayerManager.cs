using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Manager
{
    [SerializeField]
    private int _hpMax, _currentHp;
    public int HpMax =>_hpMax;
    public int CurrentHp => _currentHp;


    [SerializeField]
    private List<Element> _deck;
    public List<Element> Deck => _deck;
    
    [SerializeField]
    private int _currentGold;
    public int CurrentGold=>_currentGold;
    public MyDelegate<int> onGoldChanged;
    public MyDelegate<int> onHpChanged;

    public override void ManagerPreAwake()
    {
        base.ManagerPreAwake();
        onGoldChanged = new MyDelegate<int>();
        onHpChanged = new MyDelegate<int>();
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

    public int GetHowManyOfAnElementInDeck(Element element)
    {
        var ret = 0;
        foreach (var el in _deck)
        {
            if(el == element)
            {
                ret++;
            }
        }
        return ret;
    }
    public void EmptyGold()
    {
        SetGold(0);
    }
    public void AddGold(int amount)
    {
        SetGold(_currentGold+amount);
    }

    public void SetGold(int amount) 
    {
        _currentGold = Mathf.Clamp(amount,0,999);
        onGoldChanged.Launch(_currentGold);

    }
    public void RiseHp(int amount)
    {
        SetHp(_currentHp + amount);
    }
    public void SetHp(int newAmount)
    {
        _currentHp = Mathf.Clamp(newAmount,0,_hpMax);
        onHpChanged.Launch(_currentHp);
    }

    public void SetHpMax(int newAmount)
    {
        _hpMax = newAmount;
        onHpChanged.Launch(_currentHp);
    }

    public void RemoveElement(Element element)
    {
        _deck.Remove(element);
    }
    
}
