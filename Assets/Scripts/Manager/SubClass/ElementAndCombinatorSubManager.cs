using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ElementAndCombinatorSubManager
{
    private List<Element> _inBattleDeck, _discardPile;
    private List<Combinator> _availableElements;

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
        var combinator = Object.Instantiate(combinatorPrefab, _battleManager.board.RandomPointInBoard(), Quaternion.identity);
        combinator.Initialise(element);
        SubscribleCombinator(combinator);
    }

    public void Draw(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            Draw();
        }
    }

    private void ResetDeck()
    {
        _inBattleDeck = new List<Element>(_discardPile);
        _discardPile = new List<Element>(); 
    }
    private void DiscardCombinator(Combinator combinator)
    {
        _availableElements.Remove(combinator);
        _discardPile?.Add(combinator.element);
    }
    public void DiscardCombinator(params Combinator[] combinators)
    {
        foreach (var combinator in combinators)
        {
            DiscardCombinator(combinator);
        }
    }


    public void SubscribleCombinator(Combinator combinator)
    {
        _availableElements?.Add(combinator);
    }
}
