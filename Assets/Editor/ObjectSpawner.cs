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
        objectToSpawn = EditorGUILayout.ObjectField("Prefab to spawn", objectToSpawn, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Player"))
        {
            SpawnObject();
        }

        if (GUILayout.Button("Create Floor Grid"))
        {
            SpawnGrid();
        }

        if (GUILayout.Button("Enviroments"))
        {

        }
    }

    private void SpawnGrid()
    {
        throw new NotImplementedException();
    }

    private void SpawnObject()
    {
        if (objectToSpawn == null)
        {
            Debug.LogError("Error: Please assign an object to be spawned.");
        }
        if (objectBaseName == null)
        {
            Debug.LogError("Error: Please enter a base name for the object");
        }

        Vector2 spawnCircle = UnityEngine.Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(spawnCircle.x, 0f, spawnCircle.y);

        GameObject newObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
        newObject.name = objectBaseName + "_" + objectID;
        newObject.transform.localScale = Vector3.one * objectScale;

        objectID++;
    }
}
#endif


