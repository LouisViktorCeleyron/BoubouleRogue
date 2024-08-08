using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardMaster : MonoBehaviour
{

    [SerializeField]
    private Reward[] _rewardsArray;

    [SerializeField]
    private GoldReward TEMP_GoldReward;
    [SerializeField]
    private GatchaReward TEMP_GatchaReward;

    public void Init()
    {
        foreach (var reward in _rewardsArray)        
        {
            reward.gameObject.SetActive(false);
        }

        //faire comme avec les managers et faire un pool de 2/3 recompense de chaque (voir un en fait)
        TEMP_GatchaReward.gameObject.SetActive(true);
        TEMP_GatchaReward.Init();
        TEMP_GoldReward.gameObject.SetActive(true);
        TEMP_GoldReward.Init();
    }
    
}
