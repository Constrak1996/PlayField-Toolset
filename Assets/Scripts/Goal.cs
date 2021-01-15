using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public int countNeeded;
    public int countCurrent;
    public bool completed;

    public Task task;

   public void Incremnet(int amount)
    {
        countCurrent = Mathf.Min(countCurrent + 1, countNeeded);
        if (countCurrent >= countNeeded && !completed)
        {
            this.completed = true;
            Debug.Log("Goal Completed!");
            task.Complete();
        }
        EventController.TaskProgressChanged(task);
    }
}
