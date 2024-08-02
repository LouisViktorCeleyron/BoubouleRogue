using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnStartTurnStatus : Status
{
    protected virtual bool _DecreaseAtStart => true;
    private void OnStartTurn(FightingInstance target)
    {
        OnStartTurnAction(target);
        if(_DecreaseAtStart)
        {
            UpdateStatusInTarget(-1);
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
