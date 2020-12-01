using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static event System.Action<int> OnEnemyDied = delegate { };
    public static event System.Action<string> OnItemFound = delegate { };
    public static event System.Action<Task> OnTaskProgressedChanged = delegate { };
    public static event System.Action<Task> OnTaskCompleted = delegate { };

    public static void EnemyDied(int enemyID)
    {
        OnEnemyDied(enemyID);
    }
    public static void ItemFound(string itemId)
    {
        OnItemFound(itemId);
    }
    public static void TaskProgressChanged(Task task)
    {
        OnTaskProgressedChanged(task);
    }
    public static void TaskCompleted(Task task)
    {
        OnTaskCompleted(task);
    }
}
