using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatchaUIMaster : MonoBehaviour
{
    private GameObject _gatchaUIButton;
    [SerializeField]
    private GatchaButton[] _gatchaButtons;


    public void Init(GameObject gatchaUIButtonCaller)
    {
        _gatchaUIButton = gatchaUIButtonCaller;
        foreach (var button in _gatchaButtons) 
        { 
            button.Init(_gatchaUIButton);
        }
    }
}
