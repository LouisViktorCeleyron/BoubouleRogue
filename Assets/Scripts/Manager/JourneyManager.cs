using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyManager : Manager
{

    private PlayerManager _playerManager;
    private ConstManager _constManager;

    private int _floor;
    public MyDelegate<int> onFloorUp;

    public int realmNumber;
    public Realms currentRealms;
    private List<OpponentData> _fightedOpponent;
    private OpponentData _specificOpponent;
    


    public override void ManagerPreAwake()
    {
        _playerManager = ManagerManager.GetManager<PlayerManager>();
        _constManager = ManagerManager.GetManager<ConstManager>();
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
        var ret = currentRealms.availableOpponents[Random.Range(0, currentRealms.availableOpponents.Count-1)];
        if(_specificOpponent!= null)
        {
            ret = _specificOpponent;
            _specificOpponent = null;
        }
        if(_fightedOpponent == null)
        {
            _fightedOpponent = new List<OpponentData>();
        }
        _fightedOpponent.Add(ret);
        return ret;
    }
}
