using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Manager
{
    public FightingInstance playerInstance, opponentInstance;
    public CombineBook book;

    [SerializeField]
    private bool _playerTurn, _opponentTurn;

    public override void ManagerAwake()
    {
        StartCoroutine(Turn());
    }

    private IEnumerator Turn()
    {
        while (true) 
        { 
            _playerTurn = true;
            yield return new WaitWhile(()=>_playerTurn == true);

            OpponentTurn();
            yield return new WaitWhile(() => _opponentTurn== true);
            yield return null;
        }
    }
    
    
    public void PlayerTurn(Element a, Element b)
    {
        var c =book.GetConsequence(a, b);
        c.CallConsequence(playerInstance, opponentInstance);
    }

    public void OpponentTurn()
    {
        _opponentTurn = true;
        print("Olalal c tré le tour de l'oponent");
    }
}
