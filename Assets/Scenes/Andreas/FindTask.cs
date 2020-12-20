using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindTask : Task
{
    public static List<Node> loadedNodes = new List<Node>();
    private List<string> nodeDialog = new List<string>();
    private List<string> nodeTaskName = new List<string>();
    private List<string> nodePoints = new List<string>();
    private List<int> convertedPoints = new List<int>();
    private void Awake()
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
