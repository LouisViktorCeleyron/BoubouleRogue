using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : OnStartTurnStatus
{
    public override StatusEffect StatusEnum => StatusEffect.Needle;
    protected override bool _DecreaseAtStart => false;
    public override bool Positive => false;
    private ConstManager _constManager;
    protected override void OnStartTurnAction(FightingInstance target)
    {
        target.AutoInflictedDamage(_constManager.baseNeedleDamage * _amount);
    }

    public void ResetDamage(Attack atk)
    {
        UpdateStatusInTarget(-999);
    }
    protected override void Subscribe()
    {
        base.Subscribe();
        _constManager = ManagerManager.GetManager<ConstManager>();
        _target.OnAttackReceived.Subscribe(ResetDamage);
    }
    protected override void Unsubscribe()
    {
        _target.OnAttackReceived.Unsubscribe(ResetDamage);
        base.Unsubscribe();
    }
}
