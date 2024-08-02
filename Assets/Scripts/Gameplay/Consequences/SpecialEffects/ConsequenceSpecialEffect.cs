using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConsequenceSpecialEffect
{
    protected BattleManager _BattleManager => ManagerManager.GetManager<BattleManager>();
    protected PlayerManager _PlayerManager => ManagerManager.GetManager<PlayerManager>();
    [SerializeField]
    protected bool _use;
    public void CallEffect(FightingInstance targetInstance)
    {
        if (_use)
        {
            ApplyEffect(targetInstance);
        }
    }

    protected virtual void ApplyEffect(FightingInstance targetInstance)
    {

    }
    public string GetCSEDescription()
    {
        return _use?CSEDescription():string.Empty; 
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
    private int amount = 1;

    protected override void ApplyEffect(FightingInstance targetInstance)
    {
        _BattleManager.CombinatorSubManager.Draw(amount);
        "Ici ça pioche".ColorDebugLog(Color.green);
    }


    protected override string CSEDescription()
    {
        return $"Draw {amount.ColorizeString(ColorizeExtention.StatsColor)}. "; ;
    }
}

[System.Serializable]
public class CSE_WinGold : ConsequenceSpecialEffect
{
    [SerializeField]
    private int amount = 1;

    protected override void ApplyEffect(FightingInstance targetInstance)
    {
        _PlayerManager.AddGold(amount);
    }

    protected override string CSEDescription()
    {
        return $"Get {amount.ColorizeString(ColorizeExtention.GoldColor)} G. ";
    }
}

[System.Serializable]
public class CSE_RemoveStatus : ConsequenceSpecialEffect
{
    [SerializeField]
    private int amount = 1;
    [SerializeField]
    private bool _positive;

    protected override void ApplyEffect(FightingInstance targetInstance)
    {
        foreach (var s in targetInstance.statusEffects)
        {
            if (s.Positive == _positive)
            {
                s.UpdateStatusInTarget(-amount);
            }
        }
    }

    protected override string CSEDescription()
    {
        var positiveText = _positive ? "positive".ColorizeString(Color.green) : "negative".ColorizeString(Color.red);
        return $"Remove {amount.ColorizeString(Color.magenta)} of every {positiveText} status";
    }
}

[System.Serializable]
public class CSE_Heal : ConsequenceSpecialEffect
{
    [SerializeField]
    private int amount = 1;

    protected override void ApplyEffect(FightingInstance targetInstance)
    {
        targetInstance.Heal(amount);
    }

    protected override string CSEDescription()
    {
        return $"Heal {amount.ColorizeString(Color.green)} HP";
    }
}
