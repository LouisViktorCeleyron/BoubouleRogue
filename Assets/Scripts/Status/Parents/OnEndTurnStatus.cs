using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnEndTurnStatus : Status
{
    private void OnEndTurn(FightingInstance target)
    {
        OnEndTurnAction(target);
    }
    protected virtual void OnEndTurnAction (FightingInstance target)
    {

    }
    
    protected override void Subscribe()
    {
        _target.OnEndTurn.Subscribe(OnEndTurn);
    }
    protected override void Unsubscribe()
    {
        _target.OnEndTurn.Unsubscribe(OnEndTurn);
    }
}
