using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConsequenceSpecialEffect
{
    protected BattleManager _BattleManager => ManagerManager.GetManager<BattleManager>();
    public int ichBinEinBerliner;
    public virtual void ApplyEffect(FightingInstance targetInstance)
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
    public override void ApplyEffect(FightingInstance targetInstance)
    {
        _BattleManager.CombinatorSubManager.Draw(amount);
    }

    public override string GetConsequenceName()
    {
        return $"Draw {amount}";
    }
}
