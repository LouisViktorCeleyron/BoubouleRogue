using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : Manager
{
    private BattleManager _battleManager;
    [SerializeField]
    private LoadingSubManager _loadingSubManager;

    public override void ManagerPreAwake()
    {
        _battleManager = ManagerManager.GetManager<BattleManager>();
        _loadingSubManager.Initialize(this);
    }

    public override void ManagerOnEachSceneStart(Scene scene)
    {
        _loadingSubManager.OffTransition();
    }

    public void LoadMap()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadBattle()
    {
        _loadingSubManager.BattleTranstion(() => SceneManager.LoadScene(2));
    }
    public void LoadShop()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadInn()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene(5);
    }
}
