using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtention 
{
    public static bool IsJson(this string json)
    {
        return json[0] == '{' && json[json.Length - 1] == '}';
    }
}
