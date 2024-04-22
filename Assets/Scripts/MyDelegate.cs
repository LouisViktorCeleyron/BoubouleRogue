using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyDelegate<T>
{
    private UnityAction<T> _action;

    public void Subscribe(UnityAction<T> newAction)
    {
        _action += newAction;
    }
    public void Unsubscribe(UnityAction<T> newAction)
    {
        _action -= newAction;
    }
    public void Launch(T param)
    {
        _action.Invoke(param);
    }
}
