using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBridge : MonoBehaviour
{

    private MySceneManager _mySceneManager;
    private BattleManager _battleManager;
    private JourneyManager _journeyManager;
    private AudioManager _audioManager;

    //Peut etre que je devrais faire des subclass ici ptdr

    private void Start()
    {
        _mySceneManager = ManagerManager.GetManager<MySceneManager>();
        _battleManager = ManagerManager.GetManager<BattleManager>();
        _journeyManager = ManagerManager.GetManager<JourneyManager>();
        _audioManager = ManagerManager.GetManager<AudioManager>();
    }

    public void BattleScene()
    {
        _mySceneManager.LoadBattle();
    }
    public void BattleScene(OpponentData specificOpponent)
    {
        _journeyManager.SetSpecificOpponent(specificOpponent);
        _mySceneManager.LoadBattle("Boss");
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
    public void MenuScene()
    {
        _mySceneManager.LoadMainMenu();
    }
    public void NewRunScene()
    {
        _mySceneManager.LoadNewRunScene();
    }
    public void LoadSfx(AudioClip clip)
    {
        _audioManager.LoadSfx(clip);
    }
    public void TempDebug(string msg = "Hello World")
    {
        Debug.Log(msg);
    }
}
