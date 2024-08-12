using LCStarterContent.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ElementAndCombinatorSubManager
{
    private List<Element> _inBattleDeck, _discardPile;
    private List<Combinator> _availableElements;
    private int _playerHand;
    public int PlayerHand;
    public int maxHand = 8;

    public UnityEvent tooManyCardInHandFeedback;

    public int CombinatorsCount => _availableElements.Count;
    private PlayerManager _playerManager;
    private BattleManager _battleManager;
    public Combinator combinatorPrefab;

    public void Initialise()
    {
        _playerManager = ManagerManager.GetManager<PlayerManager>();
        _battleManager = ManagerManager.GetManager<BattleManager>();

        _inBattleDeck = new List<Element>(_playerManager.Deck);
        _discardPile = new List<Element>();
        _playerHand = 0;
    }

   
    public void ResetAvailableElements()
    {
        _availableElements = new List<Combinator>();

    }

    private void Draw()
    {
        if(_inBattleDeck.Count <=0)
        {
            if(_discardPile.Count<=0)
            {
                return;
            }
            ResetDeck();
        }
        var drawIndex = Random.Range(0,_inBattleDeck.Count);
        var drawnElement = _inBattleDeck[drawIndex];
        _inBattleDeck.RemoveAt(drawIndex);

        DrawSpecific(drawnElement);
    }

    public void DrawSpecific(Element element)
    {
        _playerHand++;
        var combinator = Object.Instantiate(combinatorPrefab, _battleManager.board.RandomPointInBoard(), Quaternion.identity);
        combinator.Initialise(element);
        SubscribleCombinator(combinator);

        if(_playerHand>maxHand)
        {
            tooManyCardInHandFeedback.Invoke();
            DiscardCombinator(combinator);
        }

    }

    public void Draw(int amount = 1)
    {
        for (int i = 0; i < Mathf.Max(amount,0); i++)
        {
            Draw();
        }
    }

    private void ResetDeck()
    {
        _inBattleDeck = new List<Element>(_discardPile);
        _discardPile = new List<Element>(); 
    }
    private void DiscardCombinator(Combinator combinator, bool destroy = false)
    {
        _playerHand--;
        _availableElements.Remove(combinator);
        if(!destroy)
        {
            _discardPile?.Add(combinator.element);
        }
        GameObject.Destroy(combinator.gameObject);
    }
    public void DiscardCombinator(bool destroy= false, params Combinator[] combinators)
    {
        foreach (var combinator in combinators)
        {
            DiscardCombinator(combinator,destroy);
        }
    }

    public void DiscardAllCombinator()
    {
        var tempList = new List<Combinator>();
        foreach (var item in _availableElements)
        {
            tempList.Add(item);
        }
        foreach (var item in tempList)
        {
            DiscardCombinator(item,false);
        }
    }
    
    public void DiscardRandomCominator()
    {
        var c =_availableElements.GetRandomElement();
        DiscardCombinator(c);
    }

    public void SubscribleCombinator(Combinator combinator)
    {
        _availableElements?.Add(combinator);
    }
}
