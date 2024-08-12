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

    public virtual bool HighPriority => false;

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
public class CSE_DrawSpecific : ConsequenceSpecialEffect
{
    [SerializeField]
    private List<DrawSpecificDico> _elementToDraw;

    protected override void ApplyEffect(FightingInstance targetInstance)
    {
        foreach (var element in _elementToDraw)
        {
            for (int i = 0; i < element.amount; i++)
            {
                _BattleManager.CombinatorSubManager.DrawSpecific(element.element);
            }
        }
    }


    protected override string CSEDescription()
    {
        var ret = string.Empty;
        foreach (var e in _elementToDraw)
        {
            ret += $"{e.amount} {e.element}".ColorizeString(e.element.color);
        }
        return $"Draw {ret}. They're  available until the end of the battle."; ;
    }
}
[System.Serializable]
public struct DrawSpecificDico
{
    public Element element;
    public int amount;
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
        var tempList = new List<Status>();
        foreach (var s in targetInstance.statusEffects)
        {
            if (s.Positive == _onlyPositiveStatus)
            {
                tempList.Add(s);
            }
        }

        foreach (var s in tempList) 
        {
            s.UpdateStatusInTarget(-_amountOfStatusToRemove);
        }
    }

    protected override string CSEDescription()
    {
        var addOrRemoveText = _amountOfStatusToRemove < 0 ? "Add" : "Remove";
        var positiveText = _onlyPositiveStatus ? "positive".ColorizeString(Color.green) : "negative".ColorizeString(Color.red);
        return $"{addOrRemoveText} {Mathf.Abs(_amountOfStatusToRemove).ColorizeString(Color.magenta)} of every {positiveText} status";
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

[System.Serializable]
public class CSE_Discard : ConsequenceSpecialEffect
{
    public override bool HighPriority => true;

    [Header("High Priority CSE")]
    [SerializeField]
    private int _discardAmount;

    protected override void ApplyEffect(FightingInstance targetInstance)
    {
        var battleManager = ManagerManager.GetManager<BattleManager>();
        var combinatorSub = battleManager.CombinatorSubManager;
        if (_discardAmount >= combinatorSub.PlayerHand)
        {
            combinatorSub.DiscardAllCombinator();
        }
        else
        {
            for (int i = 0; i < _discardAmount; i++)
            {
                combinatorSub.DiscardRandomCominator();   
            }
        }
    }

    protected override string CSEDescription()
    {
        if(_discardAmount>20) //temp
        {
            return "Discard all elements".ColorizeString(Color.red);
        }
        return $"Discard {_discardAmount.ColorizeString(Color.green)} random elements";
    }
}

