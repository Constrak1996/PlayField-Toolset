using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using JetBrains.Annotations;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
public class NPCController : EditorWindow
{
    string objectBaseName;
    GameObject checkpoint;
    Vector2 scrollPos;

    [MenuItem("PlayField/NPC Controller")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(NPCController));
    }

    private void OnGUI()
    {
        //Dont delete
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        GUILayout.Label("Create a checkpoint for your NPC to walk around)", EditorStyles.boldLabel);
        if (GUILayout.Button("Create Checkpoint"))
        {
            CreateCheckPoint();
        }

        //Dont delete
        GUILayout.EndScrollView();
    }

    private void CreateCheckPoint()
    {
        //Checkpoint prefab
        checkpoint = Resources.Load<GameObject>("Object Spawner/NPC_CheckPoint");

        if (checkpoint == null)
        {
            Debug.LogError("Error: Checkpoint could not be spawned.");
        }
        if (objectBaseName == null)
        {
            Debug.LogError("Error: Please enter a base name for the object");
        }

        GameObject newObject = Instantiate(checkpoint, new Vector3(0, 0.6f, 0), Quaternion.identity);
    }


}
#endif
