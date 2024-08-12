using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldReward : Reward
{
    [SerializeField]
    private TextMeshProUGUI _label;
    private int _goldAmount;

    private PlayerManager _playerManager;
    private JourneyManager _journeyManager;
    private ConstManager _constManager;

    public override void Init()
    {
        base.Init();
        _playerManager = ManagerManager.GetManager<PlayerManager>();
        _journeyManager = ManagerManager.GetManager<JourneyManager>();
        _constManager = ManagerManager.GetManager<ConstManager>();
        _goldAmount = ((_journeyManager.RealmNumber+1) * _constManager.baseGoldReward) + (Random.Range(0, 3) * _journeyManager.GetFloor());
        _label.text = $"{_goldAmount} Golds";
    }
    protected override void RewardVariance()
    {
        _playerManager.AddGold(_goldAmount);
    }
}


