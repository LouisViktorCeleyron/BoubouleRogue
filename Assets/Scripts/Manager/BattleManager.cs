using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleManager : Manager
{
    public FightingInstance playerInstance;
    public OponentInstance opponentInstance;

    public CombineBook book;

    public ElementAndCombinatorSubManager CombinatorSubManager;
    public BattlePreviewSubManager BattlePreviewSubManager;
    public DrawingBoard board;

    [SerializeField]
    private bool _playerTurn, _opponentTurn, _initialized;
    private PlayerManager _playerManager;
    private MySceneManager _mySceneManager;
    private JourneyManager _journeyManager;

    private WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();

    private enum TurnEvolution
    {
        PreInit,
        Init,
        PlayerTurn,
        OpTurn
    }


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
        BattlePreviewSubManager.Initialize();
        CombinatorSubManager.Initialise();
        _initialized = false;
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
        SetUpOpponent();

    }

    private IEnumerator Turn()
    {
        yield return new WaitUntil(LoopCanStart);
        InitialiseBattle();
        WaitUntil playerTurnWait = new WaitUntil(() => !_playerTurn);
        WaitUntil oponentTurnWait = new WaitUntil(() => !_opponentTurn);

        while (true) 
        { 
            StartTurn();
            playerInstance.StartTurn();
            _playerTurn = true;
            Debug.Log("Before WaitPlayer turn");
            while(_playerTurn)
            {
                yield return _waitForEndOfFrame;
            }
            "End Of Player Turn".ColorDebugLog(Color.black);
            playerInstance.EndTurn();

            opponentInstance.StartTurn();
            OpponentTurn();

            while (_opponentTurn)
            {
                yield return _waitForEndOfFrame;
            }
            opponentInstance.EndTurn();
            yield return _waitForEndOfFrame;
        }
    }

    private void Update()
    {
        
    }

    private void StartTurn()
    {
        //Checker ici
        var isDrawLess = playerInstance.GetStatus<DrawLess>();
        var drawLessStatus = isDrawLess != null ? isDrawLess.GetAmount():0;
        CombinatorSubManager.Draw(4-drawLessStatus);
    }

    public void PlayerTurn(Combinator a, Combinator b)
    {
        var c =book.GetConsequence(a.element, b.element);
        c.CallConsequence(playerInstance, opponentInstance);

        CombinatorSubManager.DiscardCombinator(a, b);
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
