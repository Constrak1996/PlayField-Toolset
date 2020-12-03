using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskDatabase : MonoBehaviour
{
    [SerializeField]
    public Dictionary<string, int[]> Tasks = new Dictionary<string, int[]>();
    [SerializeField]
    public Dictionary<string, int[]> backupTasks = new Dictionary<string, int[]>();

    private void Awake()
    {
        EventController.OnTaskProgressedChanged += UpdateTaskData;
    }
    public bool Completed(string taskName)
    {
        if (Tasks.ContainsKey(taskName))
        {
            return System.Convert.ToBoolean(Tasks[taskName][0]);
        }
        return false;
    }
    public void AddTask(Task task)
    {
        if (!Tasks.ContainsKey(task.taskName))
        {
            Tasks.Add(task.taskName, new int[] { 0, 0 });
        }
        
        if (!backupTasks.ContainsKey(task.taskName))
        {
            backupTasks.Add(task.taskName, new int[] { 0, 0 });
        }
        
    }
    public void UpdateTaskData(Task task)
    {
        Tasks[task.taskName] = new int[] { System.Convert.ToInt32(task.completed), task.goal.countCurrent};
        Debug.Log("Data updated for: " + task.taskName);
        
    }

    public void resetTask()
    {
        Tasks.Clear();
        
    }
}
