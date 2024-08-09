using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GatchaReward : Reward
{
    private UIManager _uiManager;
 

    public override void Init()
    {
        _destroyOnSelection = false;
        _uiManager = ManagerManager.GetManager<UIManager>();
        _uiManager.InitGatchaUIButton(gameObject);
        
    }


    protected override void RewardVariance()
    {
        _uiManager.ActivateGatchaUI(true);
    }

    private void UpdatePreview() 
    { 


    }

}
