using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConsequenceSpecialEffect
{
    protected BattleManager _BattleManager => ManagerManager.GetManager<BattleManager>();
    protected PlayerManager _PlayerManager => ManagerManager.GetManager<PlayerManager>();
    public bool use;
    public void CallEffect(FightingInstance targetInstance)
    {
        if(use)
        {
            ApplyEffect(targetInstance);
        }
    }

    protected virtual void ApplyEffect(FightingInstance targetInstance)
    {

    }

    public virtual string GetConsequenceName()
    {
        return GetType().ToString() + " : Default Name";
    }

}
[System.Serializable]
public class CSE_Draw:ConsequenceSpecialEffect
{
    [SerializeField]
    private int amount = 1;
    public int Amount => amount;

    protected override void ApplyEffect(FightingInstance targetInstance)
    {
        _BattleManager.CombinatorSubManager.Draw(amount);
        "Ici ça pioche".ColorDebugLog(Color.green);
    }

    public override string GetConsequenceName()
    {
        return $"Draw {amount}";
    }
}

[System.Serializable]
public class CSE_WinGold : ConsequenceSpecialEffect
{
    [SerializeField]
    private int amount = 1;
    public int Amount => amount;

    protected override void ApplyEffect(FightingInstance targetInstance)
    {
        _PlayerManager.AddGold(amount);
    }

    public override string GetConsequenceName()
    {
        return $"Win {amount} Golds";
    }
}
