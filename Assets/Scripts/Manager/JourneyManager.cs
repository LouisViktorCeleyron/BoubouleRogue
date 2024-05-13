using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyManager : Manager
{
    public int realmNumber;
    public Realms currentRealms;
    private List<OpponentData> _fightedOpponent;

    public override void ManagerPreAwake()
    {
        base.ManagerPreAwake();
    }


    public OpponentData GetOpponent()
    {
        var ret = currentRealms.availableOpponents[Random.Range(0, currentRealms.availableOpponents.Count-1)];
        if(_fightedOpponent == null)
        {
            _fightedOpponent = new List<OpponentData>();
        }
        _fightedOpponent.Add(ret);
        return ret;
    }
}
