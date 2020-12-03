using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal
{
    public string ID;

    public CollectionGoal(int amountNeeded, string itemID, Task task)
    {
        countCurrent = 0;
        countNeeded = amountNeeded;
        completed = false;
        this.task = task;
        this.ID = itemID;
        EventController.OnItemFound += ItemFound;
    }

    void ItemFound(string itemID)
    {
        if (ID == itemID)
        {
            Incremnet(1);
            if (this.completed)
            {
                EventController.OnItemFound -= ItemFound;
            }
        }
    }
}
