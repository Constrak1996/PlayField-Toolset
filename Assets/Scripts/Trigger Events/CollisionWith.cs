using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;
using Trigger = System.Collections.Generic.KeyValuePair<string, string>;

public class CollisionWith : MonoBehaviour
{
    public List<string> objToColide = new List<string>();
    
    public List<Trigger> triggerList = new List<Trigger>();
    public List<string> triggerName = new List<string>(); //Get name set name from dropdown task
    TaskGiver go;


    void Start()
    {
         go = GameObject.FindGameObjectWithTag("AddTask").GetComponent<TaskGiver>();
    }

    public struct Trigger
    {
        public Trigger(string nameValue, string objectValue)
        {
            NameData = nameValue;
            ObjectData = objectValue;
        }
        public string NameData { get; private set; }
        public string ObjectData { get; private set; }
    }

   public void AddToTriggerList(string eventName, string objColider)
    {
        
        triggerList.Add(new Trigger(eventName, objColider));
    }
    public List<Trigger> GetTriggers()
    {
        return triggerList;
    }
   
    private void OnCollisionEnter(Collision collision)
  {
       
        foreach (var item in triggerList)
        {
            foreach (var task in triggerName)
            {
                if (task == item.NameData)
                {
                    if (collision.collider.name == item.ObjectData)
                    {
                        Debug.Log("Coliding whit right object");
                        EventController.ItemFound(item.ObjectData);
                    }
                }
            }
            
        }
        
    }

   
    void Update()
    {
        triggerName = go.triggerName;
    }
}
