using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskUIItem : MonoBehaviour
{
    [SerializeField]
    private Text taskName, taskProgress;
    private Task task;

    private void Start()
    {
        EventController.OnTaskCompleted += TaskCompleted;
        EventController.OnTaskProgressedChanged += UpdateProgress;
    }
    public void Setup(Task taskToSetup)
    {
        task = taskToSetup;
        taskName.text = taskToSetup.taskName;
        taskProgress.text = taskToSetup.goal.countCurrent + "/" + taskToSetup.goal.countNeeded;
    }

    public void UpdateProgress(Task task)
    {
        if(this.task == task)
        {
            taskProgress.text = task.goal.countCurrent + "/" + task.goal.countNeeded;
        }
    }
    public void TaskCompleted(Task task)
    {
        if(this.task == task)
        {
            //Destroy(this.gameObject, 1f);
            Invoke("timer", 2);
            
        }
    }
    public void timer()
    {
        
        this.gameObject.SetActive(false);
    }
}
