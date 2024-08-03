using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System;
using System.Linq;
using Unity.VisualScripting;

[CustomPropertyDrawer(typeof(CseCollection))]
public class CseCollectionPropertyDrawer : BasePropertyDrawer
{
    private SerializedProperty _p_collection;
    private CseCollection _targetAsCseCollection;

    private bool _foldout,_gateKeeping;
    private int _selectedClass;
    private float _extraHeight;
    private List<Type> _cseSubClassList;
    private string[] _availableCseSubclass;


    public CseCollectionPropertyDrawer()
    {
        SetClassList();
    }
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label)+_extraHeight;
    }

    internal override void AtStartOfGUI(SerializedProperty property)
    {
        _targetAsCseCollection = target as CseCollection;
        _targetAsCseCollection.InitializeArray();
        numberOfLine = _foldout?3:1;
        _p_collection = property.FindPropertyRelative("_collection");
        _availableCseSubclass = _targetAsCseCollection.GetAvailableCSEArray(_cseSubClassList);
    }

    private void SetClassList()
    {
        var cseType = typeof(ConsequenceSpecialEffect);
        _cseSubClassList = new List<Type>();
        foreach (var a in System.Threading.Thread.GetDomain().GetAssemblies())
        {
            if (a.FullName.StartsWith("System."))
            {
                continue;
            }
            foreach (var t in a.GetTypes())
            {
                if (t.IsSubclassOf(cseType))
                {
                    _cseSubClassList.Add(t);
                }
            }
        }
    }
    internal override void OnGUIEffect(Rect position, SerializedProperty property)
    {

        // En gros Lets go faire un foldout avec les ellements additionels et nique les reorderable liste 
        // Comme ça j'ai juste un + avec l'enum tt en bas et un - ou un suppr a chaque niveau 
        // OH JE PEUX FAIRE UN GET NAME
        // JE suis un genie 
        // En vrai je pourrais "Presque" passer les status comme ça
        _gateKeeping = _foldout;

        DrawBase(position, property);
        if(_gateKeeping &&  _foldout)
        {
            var rectContent = MakeRectForDrawer(1, 1, 1, 0);
            rectContent.x = 16;
            DrawConsequences(rectContent, property);
            var rectButton = new Rect(rectContent.x, rectContent.y + _extraHeight, usableSpace,_baseLineHeight);
            DrawAddButton(rectButton, property);
        }
    }

    

    private void DrawConsequences(Rect contentRect, SerializedProperty property)
    {
        if(_p_collection.arraySize<=0)
        {
            return;
        }

        var tempExtraHeight = 0f;
        for (int i = 0; i < _p_collection.arraySize; i++)
        {
            DrawCSE(ref tempExtraHeight,contentRect,i); 
        }

        _extraHeight = tempExtraHeight;
    }

    private void DrawCSE(ref float tempExtraHeight, Rect contentRect, int index)
    {
        var consequenceProperty = _p_collection.GetArrayElementAtIndex(index);
        var propertySize = EditorGUI.GetPropertyHeight(consequenceProperty);
        var consequenceRect = new Rect(contentRect.x, contentRect.y + tempExtraHeight, usableSpace, propertySize);
        tempExtraHeight += propertySize;
        var button = false;
        if (propertySize > _baseLineHeight)
        {
            var deleteRect = new Rect(contentRect.x + contentRect.width/4*3, contentRect.y + tempExtraHeight, contentRect.width/4, _baseLineHeight);
            tempExtraHeight += _baseLineHeight;
            button = GUI.Button(deleteRect, "Remove");
        }

        EditorGUI.PropertyField(consequenceRect, consequenceProperty, true);
        
        if (button)
        {
            _p_collection.DeleteArrayElementAtIndex(index);
        }
    }

    private void DrawBase(Rect position, SerializedProperty property)
    {
        var rectFoldout = MakeRectForDrawer(0, 1, 1, 0);
        _foldout = EditorGUI.Foldout(rectFoldout, _foldout, property.displayName, true);
        if(!_foldout)
        {
            _extraHeight = 0;
        }
    }

    private void DrawAddButton(Rect buttonRect, SerializedProperty property)
    {
        if(_availableCseSubclass.Length > 0) 
        { 
            var rectSelectEnum = new Rect(buttonRect.x,buttonRect.y,buttonRect.width/2, buttonRect.height);
            var rectAddButton = new Rect(buttonRect.x+buttonRect.width/2, buttonRect.y, buttonRect.width / 2, buttonRect.height);
            _selectedClass = EditorGUI.Popup(rectSelectEnum, _selectedClass, _availableCseSubclass);
            var _button = GUI.Button(rectAddButton, "+", EditorStyles.miniButton);
            if(_button)
            {
                _targetAsCseCollection.AddElement(_availableCseSubclass[_selectedClass]);
            }
            property.serializedObject.ApplyModifiedProperties();
        }
        else
        {
            EditorGUI.LabelField(buttonRect, "All CSE are used by this consequence");
        }
    }
}
