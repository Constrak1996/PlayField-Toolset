using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using UnityEngine.PlayerLoop;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager.UI;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor.IMGUI.Controls;

public class CustomWindowInspector : EditorWindow
{
    enum toggleGroup
    {
        RidgetBody, Light, material, Transform, Name, Color, Tag
    }
    string aktiveGameObject,tags;
    private Vector3 myStringPos;
    private Vector3 myStringSc;
    private Vector3 myVectorRotation;
    int switchNumber;
    bool showToggle,ridgetBody,light,material,toggleTransform, toggleName,toggleColor,toggleTag;
    Color color;
    
    [MenuItem("PlayField/CustomInspector")]
    public static void init()
    {
        EditorWindow window = GetWindow<CustomWindowInspector>("CustomInspector");
    }

    void OnGUI()
    {
        EditorGUIUtility.wideMode = true;
        EditorGUILayout.BeginHorizontal();
        showToggle = GUILayout.Toggle(showToggle, "Toggle");
        EditorGUILayout.EndHorizontal();
        if (toggleTag == true)
        {
            tags = EditorGUILayout.TagField("Tag", tags);
        }
        if (toggleName == true)
        {
            aktiveGameObject = EditorGUILayout.TextField("Name", Selection.activeObject.name.Replace("(UnityEngine.GameObject)", ""));
        }
        EditorGUILayout.Space();
        if (toggleTransform == true)
        {
            EditorGUILayout.LabelField("Transform");
            myStringPos = EditorGUILayout.Vector3Field("Position", Selection.activeTransform.localPosition);
            myVectorRotation = EditorGUILayout.Vector3Field("Rotation", Selection.activeTransform.eulerAngles);
            myStringSc = EditorGUILayout.Vector3Field("Scale", Selection.activeTransform.localScale);
            foreach (GameObject item in Selection.gameObjects)
            {
                if (item != null)
                {
                    item.transform.position = myStringPos;
                    item.transform.localScale = myStringSc;
                    item.transform.eulerAngles = myVectorRotation;
                }
            }
        }
        if (toggleColor == true)
        {
            color = EditorGUILayout.ColorField("Color", color);
            if (GUILayout.Button("Color"))
            {
                Color();
            }
        }
        EditorGUILayout.Space();
        if (showToggle)
        {
            ridgetBody = GUILayout.Toggle(ridgetBody, "RidgetBody");
            light = GUILayout.Toggle(light, "Light");
            material = GUILayout.Toggle(material, "Material");
            toggleColor = GUILayout.Toggle(toggleColor, "Color");
            toggleName = GUILayout.Toggle(toggleName, "Name");
            toggleTag = GUILayout.Toggle(toggleTag, "Tag");
            toggleTransform = GUILayout.Toggle(toggleTransform, "Transform");

            switch (switchNumber)
            {
                case 1:
                    ridgetBody = true;
                    break;
                case 2:
                    light = true;
                    break;
                case 3:
                    material = true;
                    break;
                case 4:
                    toggleColor = true;
                    break;
                case 5:
                    toggleName = true;
                    break;
                case 6:
                    toggleTag = true;
                    break;
                case 7:
                    toggleTransform = true;
                    break;
            }
        }
        /*if (GUILayout.Button("Add Component"))
        {
            AddComponent();
        }*/
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
        
        Debug.Log($"OH no Not implemented yet! { name }");
    }
}
