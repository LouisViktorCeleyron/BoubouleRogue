using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haystack : OnAttackedStatus
{
    protected override void OnAttackedAction(Attack attack)
    {
        attack.GetLauncher().AddStatus<Needle>(Amount);
    }

    protected override void Subscribe()
    {
        base.Subscribe();
        _target.OnStartTurn.Subscribe(ResetHaystack);
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();
        _target.OnStartTurn.Unsubscribe(ResetHaystack);
    }

    private void ResetHaystack(FightingInstance target)
    {
        UpdateStatusInTarget(-999);
    }
}
