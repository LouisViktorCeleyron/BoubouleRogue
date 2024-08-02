using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base Dictionary non editor dictionary

[System.Serializable]
public class IntStrDictionary : MyDictionary<int, string>
{
}

[System.Serializable]
public class MyGoSoDictionary : MyDictionary<GameObject, ScriptableObject>
{

}

[System.Serializable]
public class StrTexDictionary : MyDictionary<string, Texture2D>
{

}
[System.Serializable]
public class StrColDictionary : MyDictionary<string, Color>
{
    /// <summary>
    /// Overriding this to have a nice white color
    /// </summary>
    public override void Add()
    {
        Add(string.Empty, Color.white);
    }
}

[System.Serializable]
public class StrStrDictionary : MyDictionary<string, string>
{

}

#if UNITY_EDITOR

#endif