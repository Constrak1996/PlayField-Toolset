using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskGiver : MonoBehaviour
{
    public static List<Node> loadedNodes = new List<Node>();
    private List<string> nodeDialog = new List<string>();
    private List<string> nodeTaskName = new List<string>();
    private List<string> nodePoints = new List<string>();
    private List<int> convertedPoints = new List<int>();
    private string taskType;
    private TaskController taskController;
    private Task task;
    public List<string> triggerName = new List<string>(); //Get name set name from dropdown task
    List<string> newTrigger = new List<string>();

    private void Start()
    {
        foreach (Node node in loadedNodes)
        {
            if (node.isDialog)
            {
                nodeDialog.Add(node.diaMessage);
            }
            else if (node.isQuest)
            {
                nodeTaskName.Add(node.taskMessage);
                nodePoints.Add(node.pointMessage);
                GiveTask(node.taskMessage);
            }
        }
        foreach (string point in nodePoints)
        {
            int pointHolder = Int32.Parse(point);
            convertedPoints.Add(pointHolder);
        }
        Debug.Log("this is dialog message: " + nodeDialog[0]);
        Debug.Log("this is Task Name: " + nodeTaskName[0]);
        Debug.Log("this is points: " + convertedPoints[0]);

        
        taskController = FindObjectOfType<TaskController>();
        EventController.OnTaskCompleted += Completed;
    }

    private void Update()
    {
        foreach (Node node in loadedNodes)
        {
            if (node.isDialog)
            {
                nodeDialog.Add(node.diaMessage);
            }
            else if (node.isQuest)
            {
                nodeTaskName.Add(node.taskMessage);
                nodePoints.Add(node.pointMessage);
                GiveTask(node.taskMessage);
            }
        }
        foreach (string point in nodePoints)
        {
            int pointHolder = Int32.Parse(point);
            convertedPoints.Add(pointHolder);
        }
        Debug.Log("this is dialog message: " + nodeDialog[0]);
        Debug.Log("this is Task Name: " + nodeTaskName[0]);
        Debug.Log("this is points: " + convertedPoints[0]);
    }

    public void GiveTaskSetup()
    {

        GiveTask(name);
    }
    public void GiveTask(string name)
    {
        taskType = "FindTask";
        string taskName = name;
        //string trigger = GameObject.Find("obj2label").GetComponent<Text>().text.ToString();
        AddTriggerName(name);
        task = taskController.AssaignTask(taskType, taskName);
        
    }
    public void Completed(Task task)
    {
        if (this.task != null && task == this.task)
        {
            //GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
    }
    public void AddTriggerName(string trigger)
    {
        if (!newTrigger.Contains(trigger))
        {
            newTrigger.Add(trigger);
        }
        foreach (var item in newTrigger)
        {
            if (!triggerName.Contains(item))
            {
                triggerName.Add(item);
                
            }

        }
    }
   
}
