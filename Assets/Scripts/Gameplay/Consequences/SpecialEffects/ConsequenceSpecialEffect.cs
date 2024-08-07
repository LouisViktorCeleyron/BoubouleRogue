using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConsequenceSpecialEffect
{
    [SerializeField]
    [HideInInspector]
    protected string name = "CSE";
    protected BattleManager _BattleManager => ManagerManager.GetManager<BattleManager>();
    protected PlayerManager _PlayerManager => ManagerManager.GetManager<PlayerManager>();
    [SerializeField]
    public void CallEffect(FightingInstance targetInstance)
    {
        ApplyEffect(targetInstance);
    }

    public ConsequenceSpecialEffect() 
    { 
        name = GetType().ToString().Remove(0,4);
    }

    protected virtual void ApplyEffect(FightingInstance targetInstance)
    {

    }
    public string GetCSEDescription()
    {
        return CSEDescription(); 
    }

    protected virtual string CSEDescription()
    {
        return string.Empty;
    }
}
[System.Serializable]
public class CSE_Draw : ConsequenceSpecialEffect
{
    [SerializeField]
    private int _cardsToDraw = 1;

    protected override void ApplyEffect(FightingInstance targetInstance)
    {
        _BattleManager.CombinatorSubManager.Draw(_cardsToDraw);
    }


    protected override string CSEDescription()
    {
        return $"Draw {_cardsToDraw.ColorizeString(ColorizeExtention.StatsColor)}. "; ;
    }
}

[System.Serializable]
public class CSE_WinGold : ConsequenceSpecialEffect
{
    [SerializeField]
    private int _goldWon = 1;

    protected override void ApplyEffect(FightingInstance targetInstance)
    {
        _PlayerManager.AddGold(_goldWon);
    }

    protected override string CSEDescription()
    {
        return $"Get {_goldWon.ColorizeString(ColorizeExtention.GoldColor)} G. ";
    }
}

[System.Serializable]
public class CSE_RemoveStatus : ConsequenceSpecialEffect
{

    [SerializeField]
    private int _amountOfStatusToRemove = 1;
    [SerializeField]
    private bool _onlyPositiveStatus;
    
    /*
    Si besoin ajouter le fait de retirer un statu specifique
    [SerializeField]
    private bool _specificStatus;
    */
    

    protected override void ApplyEffect(FightingInstance targetInstance)
    {
        foreach (var s in targetInstance.statusEffects)
        {
            if (s.Positive == _onlyPositiveStatus)
            {
                s.UpdateStatusInTarget(-_amountOfStatusToRemove);
            }
        }
    }

    protected override string CSEDescription()
    {
        var positiveText = _onlyPositiveStatus ? "positive".ColorizeString(Color.green) : "negative".ColorizeString(Color.red);
        return $"Remove {_amountOfStatusToRemove.ColorizeString(Color.magenta)} of every {positiveText} status";
    }
}

[System.Serializable]
public class CSE_Heal : ConsequenceSpecialEffect
{
    [SerializeField]
    private int _HpHealed = 1;

    protected override void ApplyEffect(FightingInstance targetInstance)
    {
        targetInstance.Heal(_HpHealed);
    }

    protected override string CSEDescription()
    {
        return $"Heal {_HpHealed.ColorizeString(Color.green)} HP";
    }
}
