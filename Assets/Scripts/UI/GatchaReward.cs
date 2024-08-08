using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatchaReward : Reward
{
    private UIManager _uiManager;
    
    public override void Init()
    {
        _destroyOnSelection = false;
        _uiManager = ManagerManager.GetManager<UIManager>();    
    }

    protected override void RewardVariance()
    {
        _uiManager.ActivateGatchaUI(true);
    }

}
