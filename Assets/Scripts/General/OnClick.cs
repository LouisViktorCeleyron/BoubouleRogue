using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnClick : MonoBehaviour
{
    public UnityEvent OnClickAction;

    private void OnMouseDown()
    {
        OnClickAction.Invoke();

    }
}
