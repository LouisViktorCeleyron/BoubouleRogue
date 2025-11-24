using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnEndTurnStatus : Status
{
    protected bool _shouldDecrease => true;
    private void OnEndTurn(FightingInstance target)
    {
        OnEndTurnAction(target);

        if (_shouldDecrease) 
        {
            UpdateStatusInTarget(-1);
        }
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
