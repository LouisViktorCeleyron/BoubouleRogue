using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(CombinaisonWithResult))]
public class CombinaisonPropertyDrawer : BasePropertyDrawer
{
    private SerializedProperty _p_name;
    private string _consequenceName;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property);
    }
    internal override void AtStartOfGUI(SerializedProperty property)
    {
        _p_name = property.FindPropertyRelative("name");
        _consequenceName = property.FindPropertyRelative("consequence").objectReferenceValue.name;
    }

    internal override void OnGUIEffect(Rect position, SerializedProperty property)
    {
        _p_name.stringValue = _consequenceName;
        var rect = MakeRectForDrawer(1, 0);
        EditorGUI.PropertyField(rect, property,true);
    }
}
