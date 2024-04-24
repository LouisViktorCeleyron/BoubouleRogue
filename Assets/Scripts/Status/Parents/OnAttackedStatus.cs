using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnAttackedStatus : Status
{
    private void OnAttacked(Attack attack)
    {
        var tempDamage = attack.GetDammage();
        OnAttackedAction(attack);
        ChangeAmount(-tempDamage);
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
        Debug.Log("OnAttack subscribed");
        _target.OnAttackReceived.Subscribe(OnAttacked);
    }
    protected override void Unsubscribe()
    {
        _target.OnAttackReceived.Unsubscribe(OnAttacked);
    }
}
