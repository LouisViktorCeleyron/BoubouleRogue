using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBridge : MonoBehaviour
{

    private MySceneManager _mySceneManager;
    private BattleManager _battleManager;

    private void Start()
    {
        _mySceneManager = ManagerManager.GetManager<MySceneManager>();      
        _battleManager = ManagerManager.GetManager<BattleManager>();      
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

    public void PassPlayerTurn()
    {
        _battleManager.StopPlayerTurn();
    }
}
