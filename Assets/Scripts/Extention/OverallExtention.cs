using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OverallExtention 
{
    public static void ColorDebugLog(this object toPrint, Color color)
    {
        Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{toPrint}</color>");
    }
}
