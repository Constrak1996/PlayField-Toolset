using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
   
    public List<Task> assignedTasks = new List<Task>();
    public List<Task> backupAssignedTasks = new List<Task>();

    public List<TaskData> taskSaveData = new List<TaskData>();

    [SerializeField]
    private TaskUIItem taskUItem;
    [SerializeField]
    private Transform taskUIParent;

    private TaskDatabase taskDatabase;

    private void Start()
    {
        taskDatabase = GetComponent<TaskDatabase>();
    }
    [Serializable]
    public struct TaskData
    {
        public TaskData(string taskName, string name)
        {
            Task = taskName;
            ObjectData = name;
        }
        public string Task { get; private set; }
        public string ObjectData { get; private set; }
    }
    public Task AssaignTask(string taskName, string name)
    {
        if (taskDatabase.Tasks.ContainsKey(name))
        {
            Debug.Log("Task already assigned");
            Task taskToAdd = (Task)gameObject.GetComponent(System.Type.GetType(taskName));
       
            return taskToAdd;
        }
        else
        {
            Task taskToAdd = (Task)gameObject.AddComponent(System.Type.GetType(taskName));
            assignedTasks.Add(taskToAdd);
   
           
            taskDatabase.AddTask(taskToAdd);
            taskSaveData.Add(new TaskData(taskName, name));

            return taskToAdd;
        }
        
    }
    public void ResetAssignedTask()
    {
        
        backupAssignedTasks.Clear();
        taskSaveData.Clear();
        backupAssignedTasks.AddRange(assignedTasks);
        
        assignedTasks.Clear();
        taskDatabase.resetTask();
        foreach (Transform child in taskUIParent)
        {
            child.gameObject.SetActive(false);
        }
        foreach (var item in backupAssignedTasks)
        {
            
            item.goal = new CollectionGoal(1, item.objToFind, item);
            item.completed = false;
            if (taskDatabase.Tasks.ContainsKey(name))
            {
                Debug.Log("Task already assigned");     
            }
            else
            {
               
                assignedTasks.Add(item);

                taskDatabase.AddTask(item);


            }
            TaskUIItem taskUI = Instantiate(taskUItem, taskUIParent);
            taskUI.Setup(item);
        }

    }
}
