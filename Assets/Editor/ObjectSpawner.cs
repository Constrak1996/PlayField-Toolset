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
    GameObject objectToSpawn, grid, gridParent;
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

    private void SpawnGrid(int rowlength, int columLength)
    {
        float x_Space = 1, z_Space = 1;

        gridParent = Resources.Load<GameObject>("Object Spawner/GridHolder");
        grid = Resources.Load<GameObject>("Object Spawner/FloorGrid");

        List<GameObject> gridListX = new List<GameObject>();
        List<GameObject> gridListY = new List<GameObject>();

        GameObject gridParentObject = Instantiate(gridParent);

        for (int i = 0; i < columLength * rowLength; i++)
        {
            Instantiate(grid, new Vector3(x_Space * (i % columLength), 0, z_Space * (i / columLength)), Quaternion.identity, gridParentObject.transform);
        }



        //Spawn x-axis
        //for (int i = 0; i < size; i++)
        //{
        //    GameObject gridX = Instantiate(grid, gridParentObject.transform);
        //    gridListX.Add(gridX);
        //}

        //int k = 0;
        //foreach (GameObject grid in gridListX)
        //{
        //    grid.transform.Translate(new Vector3(k, 0, 0));
        //    k++;
        //}

        ////Spawn z-axis
        //for (int j = 0; j < size; j++)
        //{
        //    GameObject gridZ = Instantiate(grid, gridParentObject.transform);
        //    gridListY.Add(gridZ);
        //}

        //int m = 0;
        //foreach (var grid in gridListY)
        //{
        //    grid.transform.Translate(new Vector3(0, 0, m));
        //    m++;
        //}
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


