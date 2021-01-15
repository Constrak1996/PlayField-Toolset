using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Task : MonoBehaviour
{
    public string taskName;
    public string objToFind;
    public string description;
    public Goal goal;
    public bool completed;
    public int points;
    public List<string> itemRewards;

    public virtual void Complete()
    {
        Debug.Log("Task Completed");
        EventController.TaskCompleted(this);
        GrantReward();
    }

    public void GrantReward()
    {
        if(completed == false)
        {
            Debug.Log("Turning in task..... grant reward");
            foreach (string item in itemRewards)
            {
                Debug.Log("Reward with: " + item + " and " + points);

            }
            completed = true;
        }
        
        
    }
}
