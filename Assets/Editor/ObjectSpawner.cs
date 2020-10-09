using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
public class ObjectSpawner : EditorWindow
{
    string objectBaseName = "";
    int objectID = 1;
    GameObject objectToSpawn;
    float objectScale;
    float spawnRadius = 5f;
    Vector2 scrollPos;

    [MenuItem("PlayField/Object Spawner")]
    public static void ShowWindow()
    {
        GetWindow(typeof(ObjectSpawner));
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn New Object", EditorStyles.boldLabel);

        objectBaseName = EditorGUILayout.TextField("Base Name", objectBaseName);
        objectID = EditorGUILayout.IntField("Object ID", objectID);
        objectScale = EditorGUILayout.Slider("Object Scale", objectScale, 0.5f, 3.0f);
        spawnRadius = EditorGUILayout.FloatField("Spawn Radius", spawnRadius);

        GUILayout.Space(20);
        GUILayout.Label("Spawn your player", EditorStyles.boldLabel);
        if (GUILayout.Button("Spawn Player"))
        {
            SpawnPlayer();
        }

        GUILayout.Space(20);
        GUILayout.Label("Design your floor grid", EditorStyles.boldLabel);
        if (GUILayout.Button("Create Floor Grid"))
        {
            SpawnGrid();
        }

        GUILayout.Space(20);

        GUILayout.Label("The Enviroment Presets");

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        if (GUILayout.Button("Office Enviroment"))
        {
            SpawnEviroment("");
        }
        if (GUILayout.Button("Office Enviroment 2"))
        {

        }
        if (GUILayout.Button("Office Enviroment 3"))
        {

        }
        if (GUILayout.Button("Office Enviroment 4"))
        {

        }
        GUILayout.EndScrollView();

    }

    private void SpawnEviroment(string path)
    {

    }

    private void SpawnGrid()
    {
        throw new NotImplementedException();
    }

    private void SpawnPlayer()
    {
        //Player Prefab
        objectToSpawn = Resources.Load<GameObject>("Object Spawner/PlayerMale");

        if (objectToSpawn == null)
        {
            Debug.LogError("Error: Please assign an object to be spawned.");
        }
        if (objectBaseName == null)
        {
            Debug.LogError("Error: Please enter a base name for the object");
        }

        GameObject newObject = Instantiate(objectToSpawn, Vector3.zero, Quaternion.identity);
        newObject.transform.localScale = Vector3.one * objectScale;
    }
}
#endif


