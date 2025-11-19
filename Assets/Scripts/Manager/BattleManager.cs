using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleManager : Manager
{
    public PlayerInstance playerInstance;
    public OponentInstance opponentInstance;

    public CombineBook book;

    public ElementAndCombinatorSubManager CombinatorSubManager;
    public BattlePreviewSubManager BattlePreviewSubManager;
    public DrawingBoard board;

    [SerializeField]
    private bool _playerTurn, _opponentTurn;
    private PlayerManager _playerManager;
    private MySceneManager _mySceneManager;
    private JourneyManager _journeyManager;
    private UIManager _uiManager;

    private WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();
    private bool _endOfBattle;

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
        _uiManager = ManagerManager.GetManager<UIManager>();


    }
    public override void ManagerOnEachSceneStart(UnityEngine.SceneManagement.Scene scene)
    {
        if (scene.name != "BattleScene")
        {
            return;
        }
        BattlePreviewSubManager.Initialize();
        CombinatorSubManager.Initialise();
        StopAllCoroutines();
        StartCoroutine(Turn());
    }
    private void SetUpOpponent()
    {
        opponentInstance.Initialise(_journeyManager.GetOpponent());
    }

    private void InitialiseBattle()
    {
        _endOfBattle = false;

        CombinatorSubManager.ResetAvailableElements();
        playerInstance.Init(_playerManager.CurrentHp, _playerManager.HpMax);
        SetUpOpponent();

    }

    private IEnumerator Turn()
    {
        yield return new WaitUntil(LoopCanStart);
        InitialiseBattle();
        WaitUntil playerTurnWait = new WaitUntil(() => !_playerTurn);
        WaitUntil oponentTurnWait = new WaitUntil(() => !_opponentTurn);

        while (!_endOfBattle) 
        { 
            StartTurn();
            opponentInstance.SetConsequence();
            playerInstance.StartTurn();
            _playerTurn = true;
            while(_playerTurn)
            {
                yield return _waitForEndOfFrame;
            }
            playerInstance.EndTurn();

            opponentInstance.StartTurn();

            //Not really clean here
            while(_endOfBattle)
            {
                yield return _waitForEndOfFrame;

            }
            OpponentTurn();
            while (_opponentTurn)
            {
                yield return _waitForEndOfFrame;
            }
            opponentInstance.EndTurn();
            yield return _waitForEndOfFrame;
        }
    }

    private void StartTurn()
    {
        //Checker ici

        var isDrawLess = playerInstance.GetStatus<DrawLess>();
        var drawLessStatus = isDrawLess != null ? isDrawLess.Amount:0;
        CombinatorSubManager.Draw(4-drawLessStatus);
    }

    public void PlayerTurn(Combinator a, Combinator b)
    {
        var c =book.GetConsequence(a.element, b.element);
        CombinatorSubManager.DiscardCombinator(c.destroyElements, a, b );
        c.CallConsequence(playerInstance, opponentInstance);
        
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
        _endOfBattle = true;
        if(!playerDead)
        {
            _playerManager.SetHp(playerInstance.Stats.GetHp());
            opponentInstance.gameObject.SetActive(false);

            _uiManager.ActivateRewardMaster(true);
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
