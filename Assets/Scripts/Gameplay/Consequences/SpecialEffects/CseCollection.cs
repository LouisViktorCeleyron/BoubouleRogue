using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CseCollection 
{
    public CSE_Draw draw;
    public CSE_WinGold winGold;
    public CSE_RemoveStatus removeStatus;
    public CSE_Heal heal;

    public void CallEffects(FightingInstance instanceTarget)
    {
        draw.CallEffect(instanceTarget);
        winGold.CallEffect(instanceTarget);
        removeStatus.CallEffect(instanceTarget);
        heal.CallEffect(instanceTarget);
    }
    

    public string GetDescription()
    {

        return
            draw.GetCSEDescription() +
            heal.GetCSEDescription() +
            removeStatus.GetCSEDescription() +
            winGold.GetCSEDescription();
    }
}
