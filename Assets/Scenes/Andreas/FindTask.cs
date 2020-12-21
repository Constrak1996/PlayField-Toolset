using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindTask : Task
{
    private void Awake()
    {
        taskName = GameObject.Find("TaskName").GetComponent<InputField>().text.ToString();
        objToFind = GameObject.Find("obj2label").GetComponent<Text>().text.ToString();
        description = "Find the key to the locked drawer";
        points = Convert.ToInt32(GameObject.Find("Points").GetComponent<InputField>().text.ToString());
        itemRewards = new List<string>() { "burnt CPU", "overloded motherbord" };
        goal = new CollectionGoal(1, objToFind, this);

    }

    public override void Complete()
    {
        base.Complete();

    }
}
