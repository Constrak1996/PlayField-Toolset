using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class FindGameObjectTags : MonoBehaviour
{
  
    public GameObject[] Tags = null;
    // Start is called before the first frame update
    void Start()
    {

     Tags = GameObject.FindGameObjectsWithTag("NPC");
        
            

        foreach (GameObject Tag in Tags)
        {
            Debug.Log("Object: " + Tag.name);

        }
    }

   
}
