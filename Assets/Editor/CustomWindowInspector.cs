using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using UnityEngine.PlayerLoop;
using System.Runtime.CompilerServices;

public class CustomWindowInspector : EditorWindow
{
    string aktiveGameObject, go;
    private Vector3 myStringPos;
    private Vector3 myStringSc;
    private Vector3 myVectorRotation;
    GameObject ridgetBody,collider;
    private SerializedObject soTarget;
    Color color;
    
    
    

    [MenuItem("PlayField/CustomInspector")]
    public static void ShowWindow()
    {
        GetWindow<CustomWindowInspector>("CustomInspector");
    }
   
    void OnGUI()
    {
        myStringPos = Selection.activeTransform.localPosition;
        myStringSc = Selection.activeTransform.localScale;
        myVectorRotation = Selection.activeTransform.eulerAngles;
        aktiveGameObject = EditorGUILayout.TextField("Name", go.Replace("(UnityEngine.GameObject)", ""));
        EditorGUIUtility.wideMode = true;
        
        Vector3 gameObjectScale = Selection.activeTransform.localScale;

        //if (GUILayout.Button("Name"))
        //{
        //    Debug.Log("Pressed");
        //}
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Name"))
        {
            aktiveGameObject = EditorGUILayout.TextField("Name", go.Replace("(UnityEngine.GameObject)", ""));
        }
        if (GUILayout.Button("Transform"))
        {
            EditorGUILayout.Vector3Field("Position", myStringPos);
            EditorGUILayout.Vector3Field("Rotation", myVectorRotation);
            EditorGUILayout.Vector3Field("Scale", myStringSc);

            color = EditorGUILayout.ColorField("Color", color);
            if (GUILayout.Button("Color"))
            {
                Color();
            }
        }
        
        GUILayout.EndHorizontal();
        
        go = Selection.activeObject.ToString();

        myStringPos = EditorGUILayout.Vector3Field("Position",myStringPos);
        myVectorRotation = EditorGUILayout.Vector3Field("Rotation", myVectorRotation);
        myStringSc = EditorGUILayout.Vector3Field("Scale", myStringSc);
        color = EditorGUILayout.ColorField("Color", color);
        if (GUILayout.Button("Color"))
        {
            Color();
        }
    }
    
    private void Color()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
    private void Update()
    {
        foreach  (GameObject item in Selection.gameObjects)
        {
            myStringPos = item.GetComponent<Vector3>();
            myStringSc = item.transform.localScale;
            myVectorRotation = item.transform.eulerAngles;
        }
    }

}
