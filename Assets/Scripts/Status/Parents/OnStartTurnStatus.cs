using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnStartTurnStatus : Status
{
    private void OnStartTurn(FightingInstance target)
    {
        OnStartTurnAction(target);
        UpdateStatusInPlayer(-1);
        if (_amount<=0)
        {
            Unsubscribe();
        }
    }
    protected virtual void OnStartTurnAction (FightingInstance target)
    {

    }
    
    protected override void Subscribe()
    {
        _target.OnStartTurn.Subscribe(OnStartTurn);
    }
    protected override void Unsubscribe()
    {
        _target.OnStartTurn.Unsubscribe(OnStartTurn);
    }
}
