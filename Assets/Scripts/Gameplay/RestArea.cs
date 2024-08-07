using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestArea : MonoBehaviour
{
    private MySceneManager _mySceneManager;
    private PlayerManager _playerManager;
    private UIManager _uiManager;

    void Start()
    {
        _playerManager = ManagerManager.GetManager<PlayerManager>();
        _mySceneManager = ManagerManager.GetManager<MySceneManager>();
        _uiManager = ManagerManager.GetManager<UIManager>();
    }

    public void HealHP()
    {
        _playerManager.RiseHp(_playerManager.HpMax / 4);
        _mySceneManager.LoadMap();
    }
    public void WinGold()
    {
        _playerManager.AddGold(50);
        _mySceneManager.LoadMap();
    }

    public void Delete()
    {
        _uiManager.ActivatePackUI(true);
    }
}
