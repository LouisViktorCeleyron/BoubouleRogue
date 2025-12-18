using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class MySceneManager : Manager
{
    private BattleManager _battleManager;
    private AudioManager _audioManager;
    private UIManager _uiManager;
    private JourneyManager _journeyManager;
    [SerializeField]
    private LoadingSubManager _loadingSubManager;
    [SerializeField]
    private GameObject _inRunUI;

    public override void ManagerPreAwake()
    {
        _battleManager = ManagerManager.GetManager<BattleManager>();
        _audioManager = ManagerManager.GetManager<AudioManager>();
        _uiManager = ManagerManager.GetManager<UIManager>();
        _journeyManager = ManagerManager.GetManager<JourneyManager>();
        _loadingSubManager.Initialize(this);
    }

    public override void ManagerOnEachSceneStart(Scene scene)
    {
        _loadingSubManager.OffTransition();
    }

    public void LoadMainMenu()
    {
        _audioManager.LoadMusic("Menu");
        LoadScene(1);
    }
    public void LoadNewRunScene()
    {
        _audioManager.LoadMusic("NewRun");
        _loadingSubManager.MenuTranstion(() => LoadScene(2));
    }
    public void LoadMap(bool riseFloor = true)
    {
        _audioManager.LoadMusic("Map");
        if(riseFloor)
        {
            _journeyManager.GoUpAFloor();
        }
        _journeyManager.CheckEndOfRealms();  
        if(_journeyManager.TEMP_winer)
        {
            return;
        }
        _loadingSubManager.MenuTranstion(() => LoadScene(3, true));
    }
    public void LoadBattle(string audioTrack = "Battle")
    {
        Debug.Log("coucou");
        _audioManager.LoadMusic(audioTrack);
        _loadingSubManager.BattleTranstion(() =>
        {
            LoadScene(4, true);
            _uiManager.DisplayBattleFeedbackUI(true);
        }
        );
    }
    public void LoadShop()
    {
        _loadingSubManager.MenuTranstion(() => LoadScene(5, true));

    }
    public void LoadInn()
    {
        _loadingSubManager.MenuTranstion(() => LoadScene(6, true));
    }
    public void LoadGameOver()
    {
        _loadingSubManager.MenuTranstion(() => LoadScene(7, true));
    }
   
    public void LoadScene(int index, bool withUI =false)
    {
        ManagerManager.OnEndScene();
        SceneManager.LoadScene(index);
        if(withUI)
        {
            _uiManager.DisplayRunUIBand();
        }
    }

}
