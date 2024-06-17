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
    private MySceneManager _mySceneManager;
    private JourneyManager _journeyManager;
   
    public override void ManagerPreAwake()
    {
        _journeyManager=ManagerManager.GetManager<JourneyManager>();
        _playerManager =ManagerManager.GetManager<PlayerManager>();
        _mySceneManager =ManagerManager.GetManager<MySceneManager>();

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
        CombinatorSubManager.ResetAvailableElements();
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
            yield return new WaitWhile(()=>_playerTurn );
            "End Of Player Turn".ColorDebugLog(Color.black);
            playerInstance.EndTurn();

            opponentInstance.StartTurn();
            OpponentTurn();
            yield return new WaitWhile(() => _opponentTurn );
            opponentInstance.EndTurn();
            yield return null;
        }
    }
   
    
    private void StartTurn()
    {
        //Checker ici
        CombinatorSubManager.Draw(4);
    }

    public void PlayerTurn(Combinator a, Combinator b)
    {
        var c =book.GetConsequence(a.element, b.element);
        c.CallConsequence(playerInstance, opponentInstance);

        CombinatorSubManager.DiscardCombinator(a, b);

        //if(CombinatorSubManager.CombinatorsCount <= 0) 
        //{
        //    _playerTurn = false;   
        //}
    }

    public void StopPlayerTurn()
    {
        _playerTurn = false;
    }

    public void OpponentTurn()
    {
        _opponentTurn = true;
        opponentInstance.LaunchConsequence(this);
        _opponentTurn = false;

    }


    public void EndOfBattle(bool playerDead = true)
    {
        if(playerDead)
        {
            _playerManager.currentHp = playerInstance.GetHp();
            _mySceneManager.LoadMap();
        }
        else
        {
            _mySceneManager.LoadGameOver();
        }
    }
    private bool LoopCanStart()
    {
        return
            board != null
            && playerInstance != null
            && opponentInstance != null;
    }

}
