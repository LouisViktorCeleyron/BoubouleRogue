using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttackedStatus : Status
{
    private void OnAttacked(Attack attack)
    {
        OnAttackedAction(attack);
        ChangeAmount(-attack.GetDammage());
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
