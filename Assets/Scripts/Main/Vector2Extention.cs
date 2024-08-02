using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Extention
{
    /// <summary>
    /// return true if the vector is in a rect
    /// </summary>
    public static bool IsInRect(this Vector2 v, Rect rect)
    {
        return (
            v.x > rect.x &&
            v.x < rect.x + rect.width &&
            v.y > rect.y &&
            v.y < rect.y + rect.height);
    }

    /// <summary>
    /// Return a Vectonr2Int.Up for editor
    /// </summary>
    public static Vector2Int EditorUp
    {
        get { return -Vector2Int.up; }
    }
    /// <summary>
    /// Return a Vectonr2Int.Down for editor
    /// </summary>
    public static Vector2Int EditorDown
    {
        get { return Vector2Int.up; }
    }
    }
