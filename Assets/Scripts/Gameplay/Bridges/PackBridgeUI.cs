using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackBridgeUI : MonoBehaviour
{
    [SerializeField]
    private StarterPack _pack;
    public StarterPack Pack => _pack;
    private StarterPackSetUp _ssup;

    [SerializeField]
    private Color _selectedColor, _unselectedColor;
    [SerializeField]
    private Image _image;

    public Color colorA, colorB;

    void Start()
    {
        _ssup = FindObjectOfType<StarterPackSetUp>();                 
    }

    public void SetUp()
    {
        _ssup.SetUpPack(this);
    }
    public void SelectFB()
    {
        _image.color = _selectedColor;    
    }
    public void UnselectFB()
    {
        _image.color = _unselectedColor;
    }
}
