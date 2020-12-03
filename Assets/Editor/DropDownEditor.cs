using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(DropDownEditorTest))]
public class DropDownEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DropDownEditorTest script = (DropDownEditorTest)target;

       
        GUIContent arrayList = new GUIContent("NpcList");
        script.GetList();
        script.listIdx = EditorGUILayout.Popup(arrayList, script.listIdx, script.NpcList.ToArray());
    }
}
