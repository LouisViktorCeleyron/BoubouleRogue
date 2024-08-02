using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WarningPopup : EditorWindow
{
    private string label;
    private MessageType typeOfWarning;

    public void Init(string label, MessageType typeOfWarning)
    {
        this.label = label;
        this.typeOfWarning = typeOfWarning;

    }

    private void OnGUI()
    {
        EditorGUILayout.HelpBox(label, typeOfWarning, true);  
    }
}

public static class CallWarning
{
    /// <summary>
    /// Warning should not be called outside of the editor 
    /// </summary>
    public static void CallWarningWindow(this object message, MessageType typeOfWarning = MessageType.Warning)
    {
        WarningPopup warningPopup = EditorWindow.GetWindow<WarningPopup>(true, typeOfWarning.ToString());
        warningPopup.Init(message.ToString(), typeOfWarning);
        warningPopup.Show();
    }
}