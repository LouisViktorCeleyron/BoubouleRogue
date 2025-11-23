using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorizeExtention 
{

    public static Color StatsColor => Color.blue;
    public static Color GoodStatusColor => Color.cyan;
    public static Color BadStatusColor => Color.red;
    public static Color DammageColor => Color.red;
    public static Color GoldColor => Color.yellow;



    public static string ColorizeStatusString(this object s, bool negative = false)
    {
        return ColorizeString(s, negative? BadStatusColor : GoodStatusColor);
    }
    public static string ColorizeString(this object s, Color color = default)
    {
        return $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{s}</color>";
    }
}
