using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : OnStartTurnStatus
{
    protected override bool _DecreaseAtStart => false;
    public override StatusEffect StatusEnum => StatusEffect.Factory;
    private BattleManager _battleManager;

    public Element element;
    protected override void OnStartTurnAction(FightingInstance target)
    {
        _battleManager.CombinatorSubManager.DrawSpecific(element);
    }

    protected override void Subscribe()
    {
        base.Subscribe();
        _battleManager = ManagerManager.GetManager<BattleManager>();
    }
}
