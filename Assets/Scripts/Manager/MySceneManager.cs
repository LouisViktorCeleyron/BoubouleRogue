using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : Manager
{
    private BattleManager _battleManager;
    public override void ManagerPreAwake()
    {
        _battleManager = ManagerManager.GetManager<BattleManager>();
    }
    public void LoadMap()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadBattle()
    {
        SceneManager.LoadScene(2);   
    }
    public void LoadShop()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadInn()
    {
        SceneManager.LoadScene(4);
    }

}
