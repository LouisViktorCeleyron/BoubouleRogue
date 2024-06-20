using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(CseCollection))]
public class CseCollectionPropertyDrawer : BasePropertyDrawer
{
    private SerializedProperty _p_collection;
    internal override void AtStartOfGUI(SerializedProperty property)
    {
        numberOfLine = 3;
        _p_collection = property.FindPropertyRelative("_collection");
    }
    internal override void OnGUIEffect(Rect position, SerializedProperty property)
    {

        // En gros Lets go faire un foldout avec les ellements additionels et nique les reorderable liste 
        // Comme ça j'ai juste un + avec l'enum tt en bas et un - ou un suppr a chaque niveau 
        // OH JE PEUX FAIRE UN GET NAME
        // JE suis un genie 
        // En vrai je pourrais "Presque" passer les status comme ça
        var rectCollection =  MakeRectForDrawer()
    }

    private void DrawConsequence()
    {

    }
}
