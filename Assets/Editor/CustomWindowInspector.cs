using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using UnityEngine.PlayerLoop;

public class CustomWindowInspector : EditorWindow
{
    string aktiveGameObject = "";
    private Vector3 myStringPos;
    private Vector3 myStringSc;
    private Vector3 myRotation;
    GameObject ridgetBody,collider;
    private SerializedObject soTarget;
    
    
    

    [MenuItem("PlayField/CustomInspector")]
    public static void ShowWindow()
    {
        GetWindow<CustomWindowInspector>("CustomInspector");
    }
   
    void OnGUI()
    {
        EditorGUIUtility.wideMode = true;
        GameObject foundObject = GameObject.Find(aktiveGameObject);
        
        Vector3 gameObjectScale = Selection.activeTransform.localScale;

        aktiveGameObject = EditorGUILayout.TextField("Name", aktiveGameObject);
        
        if (foundObject)
        {
            foundObject.transform.position = EditorGUILayout.Vector3Field("Position", foundObject.transform.position);
            foundObject.transform.localScale = EditorGUILayout.Vector3Field("Scale", foundObject.transform.localScale);
            
        }
        
        //if (GUILayout.Button("Name"))
        //{
        //    Debug.Log("Pressed");
        //}

        GUILayout.Label("Transform", EditorStyles.boldLabel);
        //myStringPos = EditorGUILayout.Vector3Field("Position", foundObject.transform.position);
        

        GUILayout.Label("Material", EditorStyles.boldLabel);

        GUILayout.Label("Collider", EditorStyles.boldLabel);
        //collider.AddComponent<Collider>();
        GUILayout.Label("Ridigbody", EditorStyles.boldLabel);
        
        
    }
    
    static Vector3 ToVector3(Vector3 position)
    {
        return new Vector3(position.x, position.y, position.x);
    }
    static Vector3 QuaternionToVector3(Quaternion rotation)
    {
        return new Vector3(rotation.x, rotation.y, rotation.z);
    }
}
