using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Manager
{
    public FightingInstance playerInstance, opponentInstance;
    public CombineBook book;

    public ElementAndCombinatorSubManager CombinatorSubManager;

    [SerializeField]
    private bool _playerTurn, _opponentTurn;


    public override void ManagerAwake()
    {
        
        CombinatorSubManager.Initialise();   
        StartCoroutine(Turn());
    }

    private IEnumerator Turn()
    {
        while (true) 
        { 
            StartTurn();
            _playerTurn = true;
            yield return new WaitWhile(()=>_playerTurn == true);

            OpponentTurn();
            yield return new WaitWhile(() => _opponentTurn== true);
            yield return null;
        }
    }

    
    private void StartTurn()
    {
        CombinatorSubManager.ResetAvailableElements();
        CombinatorSubManager.Draw(4);
    }

    public void PlayerTurn(Combinator a, Combinator b)
    {
        var c =book.GetConsequence(a.element, b.element);
        c.CallConsequence(playerInstance, opponentInstance);

        CombinatorSubManager.DiscardCombinator(a, b);

        if(CombinatorSubManager.CombinatorsCount <= 0) 
        {
            _playerTurn = false;   
        }
    }

    public void OpponentTurn()
    {
        _opponentTurn = true;
        print("Olalal c tré le tour de l'oponent");
        _opponentTurn = false;

    }

}
