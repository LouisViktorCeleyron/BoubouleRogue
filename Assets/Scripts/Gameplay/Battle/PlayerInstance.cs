using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : FightingInstance
{

    private PlayerManager _playerManager;
    private void Start()
    {
        _playerManager = ManagerManager.GetManager<PlayerManager>();
        _battleManager.playerInstance = this;
    }
    
    public void Init(int currentHp, int hpMax)
    {
        _stats.SetHpMax(hpMax);
        _stats.SetHp(currentHp);
    }

    public override void SetHpMoreFeedback()
    {
        _playerManager.SetHp(Stats.GetHp());
    }

    public override void EndOfBattle()
    {
        _battleManager.EndOfBattle(true);

    }
}
