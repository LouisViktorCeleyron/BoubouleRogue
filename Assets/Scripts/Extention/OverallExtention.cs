using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OverallExtention 
{
    public static void ColorDebugLog(this object toPrint, Color color)
    {
        Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{toPrint}</color>");
    }

    public static Vector3 ClampedVector3(this Vector3 vector, Vector3 min, Vector3 max)
    {
        return new Vector3(Mathf.Clamp(vector.x,min.x,max.x), Mathf.Clamp(vector.y,min.y,max.y), Mathf.Clamp(vector.z, min.z, max.z));
    }
}
