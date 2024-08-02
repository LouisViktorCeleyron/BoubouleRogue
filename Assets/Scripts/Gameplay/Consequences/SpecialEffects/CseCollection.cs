using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CseCollection 
{
    public CSE_Draw draw;
    public CSE_WinGold winGold;

    public void CallEffects(FightingInstance instanceTarget)
    {
        draw.CallEffect(instanceTarget);
        winGold.CallEffect(instanceTarget);
    }
    

    public string GetDescription()
    {
        var drawRet = $"Draw {draw.Amount.ColorizeString(ColorizeExtention.StatsColor)}. ";
        var wGoldRet = $"Get {winGold.Amount.ColorizeString(ColorizeExtention.GoldColor)} G. ";
        return 
            (draw.use?drawRet:string.Empty)+
            (winGold.use ? wGoldRet: string.Empty);
    }
}
