using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reward : MonoBehaviour
{
    protected bool _destroyOnSelection = true;
    public void TakeReward()
    {
        RewardVariance();
        if(_destroyOnSelection)
        {
            gameObject.SetActive(false);
        }
    }
    public virtual void Init()
    {

    }
    protected virtual void RewardVariance()
    {

    }
  
}
