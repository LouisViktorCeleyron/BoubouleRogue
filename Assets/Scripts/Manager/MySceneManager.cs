using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class MySceneManager : Manager
{
    private BattleManager _battleManager;
    private AudioManager _audioManager;
    [SerializeField]
    private LoadingSubManager _loadingSubManager;

    public override void ManagerPreAwake()
    {
        _battleManager = ManagerManager.GetManager<BattleManager>();
        _audioManager = ManagerManager.GetManager<AudioManager>();
        _loadingSubManager.Initialize(this);
    }

    public override void ManagerOnEachSceneStart(Scene scene)
    {
        _loadingSubManager.OffTransition();
    }

    public void LoadMainMenu()
    {
        _audioManager.LoadMusic("Menu");
        SceneManager.LoadScene(1);
    }
    public void LoadNewRunScene()
    {
        _audioManager.LoadMusic("NewRun");
        _loadingSubManager.MenuTranstion(() => SceneManager.LoadScene(2));
    }
    public void LoadMap()
    {
        _audioManager.LoadMusic("Map");
        _loadingSubManager.MenuTranstion(() => SceneManager.LoadScene(3));
    }
    public void LoadBattle(string audioTrack = "Battle")
    {
        _audioManager.LoadMusic(audioTrack);
        _loadingSubManager.BattleTranstion(() => SceneManager.LoadScene(4));
    }
    public void LoadShop()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadInn()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene(7);
    }
}
