using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Starter Deck", menuName ="MyStuffs/StarterDeck")]
public class StarterPack : ScriptableObject
{
    public Sprite icon;
    public MyDictionary<Element, int> elements;
    [SerializeField]
    private ColoredText[] _coloredDescription;
    public Color color;

    public string GetDescription()
    {
        var ret = string.Empty;
        foreach (var element in _coloredDescription) 
        { 
            if(element.colored)
            {
                ret += element.text.ColorizeString(color);
            }
            else
            {
                ret += element.text;
            }
        }

        return ret;
    }
}

[System.Serializable]
public struct ColoredText
{
    public string text;
    public bool colored;
}
