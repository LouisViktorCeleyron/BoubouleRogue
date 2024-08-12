using LCStarterContent.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyManager : Manager
{

    private PlayerManager _playerManager;
    private ConstManager _constManager;
    private MySceneManager _mapManager;

    private int _floor;
    public MyDelegate<int> onFloorUp;

    [SerializeField]
    private int _realmNumber;
    public int RealmNumber=>_realmNumber;
    [SerializeField]
    private Realms[] _realms;
    private Realms _CurrentRealms => _realms[_realmNumber];
    private List<OpponentData> _fightedOpponent;
    private OpponentData _specificOpponent;
    private bool _isBossBattle;
    public bool TEMP_winer;


    public override void ManagerPreAwake()
    {
        _playerManager = ManagerManager.GetManager<PlayerManager>();
        _constManager = ManagerManager.GetManager<ConstManager>();
        _mapManager = ManagerManager.GetManager<MySceneManager>();
        onFloorUp = new MyDelegate<int>();
    }

    public void GoUpAFloor()
    {
        _floor++;
        onFloorUp.Launch(_floor);
    }
    public int GetFloor() 
    { 
        return _floor;
    }

    public void UpRealm()
    {
        _playerManager.SetHp(999);
        _realmNumber++;
        _floor = 0;
        _isBossBattle = false;
        if(_realmNumber >= _realms.Length)
        {
            TEMP_winer = true;
            _mapManager.LoadGameOver();
        }
    }

    public void NewRunSetup()
    {
        _floor = -1;
        GoUpAFloor();
        _playerManager.SetGold(_constManager.basePlayerGold);
        _playerManager.SetHpMax(_constManager.basePlayerHP);
        _playerManager.SetHp(_constManager.basePlayerHP);
    }

    public void SetSpecificOpponent(OpponentData newSpecificOpponent)
    {
        _specificOpponent = newSpecificOpponent;
    }

    public OpponentData GetOpponent()
    {
        var ret = _CurrentRealms.availableOpponents[Random.Range(0, _CurrentRealms.availableOpponents.Count-1)];
        if(_specificOpponent!= null)
        {
            ret = _specificOpponent;
            _specificOpponent = null;
        }
        _fightedOpponent.AddToListWithSecurity(ret);
        return ret;
    }

    public void SetBoss()
    {
        _specificOpponent = _CurrentRealms.boss;
        _isBossBattle = true;
    }
    public void CheckEndOfRealms()
    {
        if(_isBossBattle) 
        { 
            UpRealm();
        }
    }
}
