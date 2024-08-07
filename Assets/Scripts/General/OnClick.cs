using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnClick : MonoBehaviour
{
    public UnityEvent OnClickAction;
    private UIManager _uiManager;
    public bool canClick = true;
    private void Start()
    {
        _uiManager = ManagerManager.GetManager<UIManager>();
    }

    private void OnMouseDown()
    {
        if(!canClick) 
        { 
            return;
        }
        if(_uiManager.IsUIOnFront())
        {
            return; 
        }
        OnClickAction.Invoke();

    }
}
