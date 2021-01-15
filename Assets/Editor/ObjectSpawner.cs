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
public class ObjectSpawner : EditorWindow
{
    string objectBaseName = "";
    int objectID = 1;
    GameObject objectToSpawn, grid, gridParent, checkpoint;
    static GameObject gridDestroyer;
    float objectScale;
    int gridSize;
    Vector2 scrollPos;

    public int rowLength, columLength;

    [MenuItem("PlayField/Object Spawner")]
    public static void ShowWindow()
    {
        GetWindow(typeof(ObjectSpawner));
    }

    private void OnGUI()
    {
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        GUILayout.Label("Spawn your player (if there isn't already one)", EditorStyles.boldLabel);
        if (GUILayout.Button("Spawn Playable Character"))
        {
            SpawnPlayer();
        }

        GUILayout.Space(20);
        GUILayout.Label("Design your floor grid", EditorStyles.boldLabel);
        columLength = EditorGUILayout.IntField("Length", columLength);
        rowLength = EditorGUILayout.IntField("Width", rowLength);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Create Floor Grid"))
        {
            SpawnGrid(rowLength, columLength);
        }
        if (GUILayout.Button("Remove Grid"))
        {

        }
        GUILayout.EndHorizontal();

        GUILayout.Space(20);

        GUILayout.Label("Enviroment Presets", EditorStyles.boldLabel);

        // -------------------------------------------------------------------------
        // Enviroments
        
        if (GUILayout.Button("Office Enviroment"))
        {
            SpawnEviroment("Object Spawner/Enviroments/Enviroment 1");
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

        GUILayout.Space(20);

        GUILayout.Label("Create a checkpoint for your NPC to walk around", EditorStyles.boldLabel);
        if (GUILayout.Button("Create Checkpoint"))
        {
            CreateCheckPoint();
        }

        GUILayout.Space(20);
        GUILayout.Label("Character Animation Selector", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Character"));
        {

        }
        GUIContent animationLabel = new GUIContent("Default");
        EditorGUILayout.DropdownButton(animationLabel, FocusType.Passive);

        GUILayout.EndHorizontal();

        //Makes menu scrollable
        GUILayout.EndScrollView();

    }

    private void SpawnEviroment(string path)
    {
        GameObject enviroment = Resources.Load<GameObject>(path);
        Instantiate(enviroment);
    }

    private void SpawnGrid(int rowlength, int columLength)
    {
        float x_Space = 1, z_Space = 1;

        gridParent = Resources.Load<GameObject>("Object Spawner/GridHolder");
        grid = Resources.Load<GameObject>("Object Spawner/FloorGrid");

        List<GameObject> gridListX = new List<GameObject>();
        List<GameObject> gridListY = new List<GameObject>();

        GameObject gridParentObject = Instantiate(gridParent);

        //Spawn floor grid
        for (int i = 0; i < columLength * rowLength; i++)
        {
            Instantiate(grid, new Vector3(x_Space * (i % columLength), 0, z_Space * (i / columLength)), Quaternion.identity, gridParentObject.transform);
        }
    }

    private void SpawnPlayer()
    {
        //Player Prefab
        objectToSpawn = Resources.Load<GameObject>("Object Spawner/Player");

        if (objectToSpawn == null)
        {
            Debug.LogError("Error: Please assign an object to be spawned.");
        }
        if (objectBaseName == null)
        {
            Debug.LogError("Error: Please enter a base name for the object");
        }

        GameObject newObject = Instantiate(objectToSpawn, new Vector3(0,0.6f,0), Quaternion.identity);
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


