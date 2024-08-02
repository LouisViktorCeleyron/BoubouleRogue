using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnStatusStatus : Status
{
    private void OnStatusInflicted(Status statusInflicted)
    {
        OnStatusInflictedAction(statusInflicted);
    }
    protected virtual void OnStatusInflictedAction(Status statusInflicted)
    {

    }
    
    protected override void Subscribe()
    {
        _target.OnStatusInflicted.Subscribe(OnStatusInflicted);
    }
    protected override void Unsubscribe()
    {
        _target.OnStatusInflicted.Unsubscribe(OnStatusInflicted);
    }
}
