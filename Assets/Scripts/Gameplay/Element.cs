using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Element", menuName ="MyStuffs/Element")]
public class Element : ScriptableObject
{
    public Sprite icone;
    public int basePrice=111;
    public string description;
    public Color color;
    public Element[] potentialMix;


    public string GetColoredElementName()
    {
        return name.ColorizeString(color);
    }
}
