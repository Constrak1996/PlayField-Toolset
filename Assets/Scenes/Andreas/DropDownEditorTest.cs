using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownEditorTest : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] Tags;
    
    [HideInInspector]
    public int listIdx = 0;
    [HideInInspector]
    public List<string> NpcList;

    public void GetList()
    {
        NpcList.Clear();
        Tags = GameObject.FindGameObjectsWithTag("NPC");

        foreach (GameObject Tag in Tags)
        {

            NpcList.Add(Tag.name);
        }
    }



}
