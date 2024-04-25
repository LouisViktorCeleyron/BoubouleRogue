using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnAttackedStatus : Status
{
    private void OnAttacked(Attack attack)
    {
        "Attacked".ColorDebugLog(Color.yellow);
        OnAttackedAction(attack);
        if(_amount<=0)
        {
            Unsubscribe();
        }
    }
    protected virtual void OnAttackedAction (Attack attack)
    {

    }
    
    protected override void Subscribe()
    {
        _target.OnAttackReceived.Subscribe(OnAttacked);
    }
    protected override void Unsubscribe()
    {
        _target.OnAttackReceived.Unsubscribe(OnAttacked);
    }
}
