using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using UnityEngine.PlayerLoop;

public class CustomWindowInspector : EditorWindow
{
    string myString = "";
    Vector3 myStringPos, myStringSc;
    Quaternion myStringRot;
    Vector4 value;
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
        value = QuaternionToVector4(Selection.activeTransform.rotation);
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
        value = EditorGUILayout.Vector4Field("Rotation", value);

        myStringSc = EditorGUILayout.Vector3Field("Scale", scale);

        GUILayout.Label("Material", EditorStyles.boldLabel);

        GUILayout.Label("Collider", EditorStyles.boldLabel);
        //collider.AddComponent<Collider>();
        GUILayout.Label("Ridigbody", EditorStyles.boldLabel);
    }

    static Vector4 QuaternionToVector4(Quaternion rotation)
    {
        return new Vector4(rotation.x, rotation.y, rotation.z, rotation.w);
    }
}
