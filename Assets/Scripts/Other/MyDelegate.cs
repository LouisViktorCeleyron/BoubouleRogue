using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyDelegate<T>
{
    private UnityAction<T> _action;

    public List<string> DEBUG_MethodStringList;

    public void Subscribe(UnityAction<T> newAction)
    {
        //$"{newAction.Method.Name} Subscribed".ColorDebugLog(Color.red);
        _action += newAction;
    }
    public void Unsubscribe(UnityAction<T> newAction)
    {
        //$"{newAction.Method.Name} Unubscribed".ColorDebugLog(Color.red);
        _action -= newAction;
    }
    public void Launch(T param)
    {
        _action?.Invoke(param);
    }
}

public class MyDelegate
{
    private UnityAction _action;

    public void Subscribe(UnityAction newAction)
    {
        //$"{newAction.Method.Name} Subscribed".ColorDebugLog(Color.red);
        _action += newAction;
    }
    public void Unsubscribe(UnityAction newAction)
    {
        //$"{newAction.Method.Name} Unubscribed".ColorDebugLog(Color.red);
        _action -= newAction;
    }
    public void Launch()
    {
        _action?.Invoke();
    }
}
