using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskGiver : MonoBehaviour
{
    
    private string taskName;
    private TaskController taskController;
    private Task task;
    public List<string> triggerName = new List<string>(); //Get name set name from dropdown task
    List<string> newTrigger = new List<string>();
    private void Start()
    {
        taskController = FindObjectOfType<TaskController>();
        EventController.OnTaskCompleted += Completed;
    }
    public void GiveTaskSetup()
    {

        GiveTask();
    }
    public void GiveTask()
    {
        taskName = "FindTask";
        string name = GameObject.Find("TaskName").GetComponent<InputField>().text.ToString();
        string trigger = GameObject.Find("obj2label").GetComponent<Text>().text.ToString();
        AddTriggerName(name);
        task = taskController.AssaignTask(taskName, name);
        
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
