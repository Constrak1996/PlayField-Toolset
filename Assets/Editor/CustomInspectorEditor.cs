using UnityEngine;
using UnityEditor;
using System.Diagnostics;


public class CustomInspectorEditor : Editor
{
    public CustomInspector myTarget;
    private SerializedObject soTarget;

    private SerializedProperty stringVar1;
    private SerializedProperty stringVar2;
    private SerializedProperty stringVar3;
    private SerializedProperty stringVar4;
    private SerializedProperty stringVar5;

    private void OnEnable()
    {
        myTarget = (CustomInspector)target;
        soTarget = new SerializedObject(target);
        stringVar1 = soTarget.FindProperty("stringVar1");
        stringVar2 = soTarget.FindProperty("stringVar2");
        stringVar3 = soTarget.FindProperty("stringVar3");
        stringVar4 = soTarget.FindProperty("stringVar4");
        stringVar5 = soTarget.FindProperty("stringVar5");
    }
    public override void OnInspectorGUI()
    {
        soTarget.Update();
        EditorGUI.BeginChangeCheck();
        //DrawDefaultInspector();
        myTarget.toolBarTap = GUILayout.Toolbar(myTarget.toolBarTap, new string[] { "Name", "Transform", "Material", "Collider", "Ridigbody" });
        //myTarget.currentButtom = GUILayout.Toolbar(myTarget.currentButtom, new string[] { }); If second row of button is needed
       
        switch (myTarget.toolBarTap)
        {
            case 0: 
                myTarget.currentTab = "Name";
                break;
            case 1:
                myTarget.currentTab = "Transform";
                break;
            case 2:
                myTarget.currentTab = "Material";
                break;
            case 3:
                myTarget.currentTab = "Collider";
                break;
            case 4:
                myTarget.currentTab = "Ridigbody";
                break;
        }

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }
        EditorGUI.BeginChangeCheck();
        switch (myTarget.currentTab)
        {
            case "Name":
                EditorGUILayout.PropertyField(stringVar1);
                break;
            case "Transform":
                EditorGUILayout.PropertyField(stringVar2);
                break;
            case "Material":
                EditorGUILayout.PropertyField(stringVar3);
                break;
            case "Collider":
                EditorGUILayout.PropertyField(stringVar4);
                break;
            case "Ridigbody":
                EditorGUILayout.PropertyField(stringVar5);
                break;
            
        }
        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
        }
        
    }
}
