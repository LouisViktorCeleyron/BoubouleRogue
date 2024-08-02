using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBridge : MonoBehaviour
{

    private MySceneManager _mySceneManager;
    private BattleManager _battleManager;
    private JourneyManager _journeyManager;
    private AudioManager _audioManager;

    private void Start()
    {
        _mySceneManager = ManagerManager.GetManager<MySceneManager>();
        _battleManager = ManagerManager.GetManager<BattleManager>();
        _journeyManager = ManagerManager.GetManager<JourneyManager>();
        _audioManager = ManagerManager.GetManager<AudioManager>();
    }

    public void BattleScene()
    {
        _audioManager.LoadMusic("Battle");
        _mySceneManager.LoadBattle();
    }
    public void BattleScene(OpponentData specificOpponent)
    {
        _audioManager.LoadMusic("Boss");
        _journeyManager.SetSpecificOpponent(specificOpponent);
        _mySceneManager.LoadBattle();
    }
    public void MapScene()
    {
        _mySceneManager.LoadMap();
    }
    public void ShopScene()
    {
        _mySceneManager.LoadShop();
    }
    public void InnScene()
    {
        _mySceneManager.LoadInn();
    }

    public void PassPlayerTurn()
    {
        _battleManager.StopPlayerTurn();
    }
}
