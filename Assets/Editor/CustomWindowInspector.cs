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
    private Vector3 myStringPos, setMyStringPos;
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
        EditorGUIUtility.wideMode = true;
        
        EditorGUILayout.BeginHorizontal();
        showName = EditorGUILayout.BeginFoldoutHeaderGroup(showName, "Name");
        EditorGUILayout.EndFoldoutHeaderGroup();
        ShowTransform = EditorGUILayout.BeginFoldoutHeaderGroup(ShowTransform, "Transform");
        EditorGUILayout.EndFoldoutHeaderGroup();
        EditorGUILayout.EndHorizontal();
        if (showName)
        {
            go = Selection.activeObject.ToString();
            aktiveGameObject = EditorGUILayout.TextField("Name", go.Replace("(UnityEngine.GameObject)", ""));
            foreach (GameObject itemName in Selection.gameObjects)
            {
                itemName.name = aktiveGameObject;
            }
            
        }
        
        if (ShowTransform)
        {
            myStringPos = EditorGUILayout.Vector3Field("Position", Selection.activeTransform.localPosition);
            myVectorRotation = EditorGUILayout.Vector3Field("Rotation", Selection.activeTransform.eulerAngles);
            myStringSc = EditorGUILayout.Vector3Field("Scale", Selection.activeTransform.localScale);
            foreach  (GameObject item in Selection.gameObjects)
            {
                item.transform.position = myStringPos;
                item.transform.localScale = myStringSc;
                item.transform.eulerAngles = myVectorRotation;
            }
           
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
            Renderer renderer = obj.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = color;
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
