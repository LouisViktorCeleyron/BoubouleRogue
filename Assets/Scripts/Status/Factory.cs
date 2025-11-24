using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Factory : OnStartTurnStatus
{
    protected override bool _DecreaseAtStart => false;
    public override StatusEffect StatusEnum => StatusEffect.Factory;
    private BattleManager _battleManager;

    public override string Name => $"{element.name} {base.Name}";

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

    public override string GetDescription()
    {
        return $"Draw {("1" + Name).ColorizeStatusString()} at the start of every turn";
    }
}
