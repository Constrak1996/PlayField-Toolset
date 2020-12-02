using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using UnityEngine.PlayerLoop;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager.UI;

public class CustomWindowInspector : EditorWindow
{
    string aktiveGameObject, go;
    private Vector3 myStringPos;
    private Vector3 myStringSc;
    private Vector3 myVectorRotation;
    private SerializedObject soTarget;
    bool showName,ShowTransform;
    
    Color color;
    
    
    

    [MenuItem("PlayField/CustomInspector")]
    public static void init()
    {
        EditorWindow window = GetWindow<CustomWindowInspector>("CustomInspector");
        
    }

    private void OnEnable()
    {

    }
    void OnGUI()
    {
        myStringPos = Selection.activeTransform.localPosition;
        myStringSc = Selection.activeTransform.localScale;
        myVectorRotation = Selection.activeTransform.eulerAngles;
        EditorGUIUtility.wideMode = true;
        go = Selection.activeObject.ToString();
        Vector3 gameObjectScale = Selection.activeTransform.localScale;
        EditorGUILayout.BeginHorizontal();
        showName = EditorGUILayout.BeginFoldoutHeaderGroup(showName, "Name");
        EditorGUILayout.EndFoldoutHeaderGroup();
        ShowTransform = EditorGUILayout.BeginFoldoutHeaderGroup(ShowTransform, "Transform");
        EditorGUILayout.EndFoldoutHeaderGroup();
        EditorGUILayout.EndHorizontal();
        if (showName)
        {
            aktiveGameObject = EditorGUILayout.TextField("Name", go.Replace("(UnityEngine.GameObject)", ""));
        }
        
        if (ShowTransform)
        {
            myStringPos = EditorGUILayout.Vector3Field("Position", myStringPos);
            myVectorRotation = EditorGUILayout.Vector3Field("Rotation", myVectorRotation);
            myStringSc = EditorGUILayout.Vector3Field("Scale", myStringSc);
            color = EditorGUILayout.ColorField("Color", color);
            if (GUILayout.Button("Color"))
            {
                Color();
            }
        }
        
        if (GUILayout.Button("Add Component"))
        {
            AddComponent();
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

    private void AddComponent()
    {
        Debug.Log("OH no Not implemented yet!");
    }
    private void Update()
    {
        
    }

}
