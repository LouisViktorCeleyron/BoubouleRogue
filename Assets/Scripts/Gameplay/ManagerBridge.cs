using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBridge : MonoBehaviour
{

    private MySceneManager _mySceneManager;

    private void Start()
    {
        _mySceneManager = ManagerManager.GetManager<MySceneManager>();      
    }

    public void BattleScene()
    {
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
}
