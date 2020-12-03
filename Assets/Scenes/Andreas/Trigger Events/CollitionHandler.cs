using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Trigger = System.Collections.Generic.KeyValuePair<string, string>;

public class CollitionHandler : MonoBehaviour
{
    private int methodToUse;
   

  

    public void DropDownHandler(int value)
    {
        if (value == 1)
        {
            methodToUse = 1;
        }
        if (value == 2)
        {
            methodToUse = 2;
        }
        else
        {
            Debug.Log("Chose what type of colition");
        }
    }

    public void AddScript()
    {
        switch (methodToUse)
        {
            case 1: //Collision with
                CollisionWith();

                //GameObject.Find("TriggerDropdown").GetComponent<TaskDropHandler>().InsertTriggerEvents();
                break;
            case 2: //Remove collision with
                ColisionWithRemove();
                break;
            default:
               
                break;
        }
    }

    public void CollisionWith()
    {
        string tmp = GameObject.Find("obj1Label").GetComponent<Text>().text.ToString();
        string tmp2 = GameObject.Find("obj2label").GetComponent<Text>().text.ToString();
        string name = GameObject.Find("TaskName").GetComponent<InputField>().text.ToString();

        
        GameObject go = GameObject.Find(tmp);
        if (go.GetComponent<CollisionWith>())
        {
            if (GameObject.Find("TriggerDropdown").GetComponent<TaskDropHandler>().triggers.Contains(name))
            {
                Debug.Log("Trigger already exist");
            }
            else
            {
                go.GetComponent<CollisionWith>().objToColide.Add(tmp2);
                GameObject.Find("TriggerDropdown").GetComponent<TaskDropHandler>().triggers.Add(name);
                go.GetComponent<CollisionWith>().AddToTriggerList(name, tmp2);
            }

        }
        else
        {
            if (GameObject.Find("TriggerDropdown").GetComponent<TaskDropHandler>().triggers.Contains(name))
            {
                Debug.Log("Trigger already exist");
            }
            else
            {
                go.AddComponent<CollisionWith>();
                go.GetComponent<CollisionWith>().objToColide.Add(tmp2);
                GameObject.Find("TriggerDropdown").GetComponent<TaskDropHandler>().triggers.Add(name);
                go.GetComponent<CollisionWith>().AddToTriggerList(name, tmp2);
            }
            
        }   
    }

    public void ColisionWithRemove()
    {
        string tmp = GameObject.Find("obj1").GetComponent<InputField>().text.ToString();
        string tmp2 = GameObject.Find("obj2").GetComponent<InputField>().text.ToString();
        string name = GameObject.Find("TriggerName").GetComponent<InputField>().text.ToString();

        GameObject go = GameObject.Find(tmp);

        foreach (var item in go.GetComponent<CollisionWith>().triggerList)
        {
            if(item.NameData == name && item.ObjectData == tmp2)
            {
               go.GetComponent<CollisionWith>().objToColide.Remove(tmp2);
               break;
            }
        }
    }


        
}
