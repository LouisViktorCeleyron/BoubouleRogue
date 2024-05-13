using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class BattleManager : Manager
{
    public FightingInstance playerInstance;
    public OponentInstance opponentInstance;

    public CombineBook book;

    public ElementAndCombinatorSubManager CombinatorSubManager;
    public DrawingBoard board;


    [SerializeField]
    private bool _playerTurn, _opponentTurn;
    private PlayerManager _playerManager;
    private JourneyManager _journeyManager;
   
    public override void ManagerPreAwake()
    {
        _journeyManager=ManagerManager.GetManager<JourneyManager>();
        _playerManager =ManagerManager.GetManager<PlayerManager>();

    }
    public override void ManagerOnEachSceneStart(UnityEngine.SceneManagement.Scene scene)
    {
        if (scene.name != "BattleScene")
        {
            return;
        }
        CombinatorSubManager.Initialise();
        StartCoroutine(Turn());
    }
    private void SetUpOpponent()
    {
        opponentInstance.Initialise(_journeyManager.GetOpponent());
    }

    private void InitialiseBattle()
    {
        playerInstance.SetHp(_playerManager.currentHp);
    }

    private IEnumerator Turn()
    {
        yield return new WaitUntil(LoopCanStart);
        SetUpOpponent();
        InitialiseBattle();
        while (true) 
        { 
            StartTurn();
            playerInstance.StartTurn();
            _playerTurn = true;
            yield return new WaitWhile(()=>_playerTurn == true);
            playerInstance.EndTurn();

            opponentInstance.StartTurn();
            OpponentTurn();
            yield return new WaitWhile(() => _opponentTurn== true);
            opponentInstance.EndTurn();
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
        opponentInstance.LaunchConsequence(this);
        _opponentTurn = false;

    }
    public void EndOfBattle()
    {
        _playerManager.currentHp = playerInstance.GetHp();
    }
    private bool LoopCanStart()
    {
        Debug.Log("Hey");
        return
            board != null
            && playerInstance != null
            && opponentInstance != null;
    }

}
