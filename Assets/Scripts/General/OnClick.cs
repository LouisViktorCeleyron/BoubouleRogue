using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class OnClick : MonoBehaviour
{
    public UnityEvent OnClickAction;
    private UIManager _uiManager;
    private bool _canClick = true;
    //Temp


    private void Start()
    {
        _uiManager = ManagerManager.GetManager<UIManager>();
    }

    public void Enable()
    {
        _canClick = true;
    }
    public void Disable() 
    { 
        _canClick = false;
    }

    private void OnMouseDown()
    {
        if (!_canClick)
        {
            return;
        }
        if (_uiManager.IsUIOnFront())
        {
            return;
        }
        OnClickAction.Invoke();
    }

}
