using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class CustomWindowInspector : EditorWindow
{
    string myString = "";
    Vector3 myStringPos, myStringSc;
    Quaternion myStringRot;
    GameObject ridgetBody,collider;
    
    [MenuItem("PlayField/CustomInspector")]
    public static void ShowWindow()
    {
        GetWindow<CustomWindowInspector>("CustomInspector");
    }
   
    void OnGUI()
    {
        var aktiveGameObject = Selection.activeObject.name.TrimEnd();
        Vector3 pos = Selection.activeGameObject.transform.position;
        Quaternion rot = Selection.activeGameObject.transform.rotation;
        Vector3 scale = Selection.activeGameObject.transform.localScale;
        var rotation = "Rotation";
        myString = EditorGUILayout.TextField("Name", aktiveGameObject);
        myString.Trim();
        if (GUILayout.Button("Name"))
        {
            Debug.Log("Pressed");
        }

        GUILayout.Label("Transform", EditorStyles.boldLabel);
        myStringPos = EditorGUILayout.Vector3Field("Position", pos);
       
        myStringSc = EditorGUILayout.Vector3Field("Scale", scale);

        GUILayout.Label("Material", EditorStyles.boldLabel);

        GUILayout.Label("Collider", EditorStyles.boldLabel);
        //collider.AddComponent<Collider>();
        GUILayout.Label("Ridigbody", EditorStyles.boldLabel);
        ridgetBody.AddComponent<Rigidbody>();

    }
}
