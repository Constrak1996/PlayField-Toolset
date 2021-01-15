using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum NodeType {Dialog, Quest};

public class Node
{
    public Rect rect;
    public NodeType type;
    public string title;
    public bool toggleBool = false;
    private bool gameObjectBool = false;
    public string diaMessage = "Enter message here";
    public string taskMessage = "Enter name here";
    public string pointMessage = "Enter point here";
    public bool isDragged, isSelected, isDialog = false, isQuest = false;
    private int gameObjectCount = 0;
    private List<GameObject> gameObjectsList = new List<GameObject>();
    private string[] gameObjectsName = {"Shit", "Lort", "Fuck" };

    public EdgePoint inPoint;
    public EdgePoint outPoint;

    public GUIStyle style;
    public GUIStyle defaultNodeStyle;
    public GUIStyle selectedNodeStyle;

    public Action<Node> OnRemoveNode;
    public Action<Node> RemoveConnectedNode;
    private bool isDoneSearching = false;

    public Node(Vector2 position, float width, float height, GUIStyle nodeStyle, GUIStyle selectedStyle, GUIStyle inPointStyle, GUIStyle outPointStyle, Action<EdgePoint> OnClickInPoint, Action<EdgePoint> OnClickOutPoint, Action<Node> OnClickRemoveNode, NodeType type, Action<Node> RemoveConnectedNode)
    {
        rect = new Rect(position.x, position.y, width, height);
        style = nodeStyle;
        inPoint = new EdgePoint(this, EdgePointType.In, inPointStyle, OnClickInPoint);
        outPoint = new EdgePoint(this, EdgePointType.Out, outPointStyle, OnClickOutPoint);
        defaultNodeStyle = nodeStyle;
        selectedNodeStyle = selectedStyle;
        OnRemoveNode = OnClickRemoveNode;
        this.RemoveConnectedNode = RemoveConnectedNode;
        this.type = type;
    }

    public void Drag(Vector2 delta)
    {
        rect.position += delta;
    }

    public void Draw()
    {
        inPoint.Draw();
        outPoint.Draw();
        switch (type)
        {
            case NodeType.Dialog:
                GUI.Box(rect, title, style);
                GUI.Label(new Rect(rect.center.x - 90, (rect.center.y + 35) - 50, 60, 15), "Message");
                GUI.Label(new Rect(rect.center.x - 20, (rect.center.y + 20) - 50, 50, 16), "Dialog");
                diaMessage = GUI.TextField(new Rect(rect.center.x - 90, rect.center.y, 175, 20), diaMessage);
                isDialog = true;
                break;

            case NodeType.Quest:
                GUI.Box(rect, title, style);
                GUI.Label(new Rect(rect.center.x - 20, (rect.center.y - 10) - 50, 50, 15), "Quest");
                GUI.Label(new Rect(rect.center.x - 90, (rect.center.y + 5) - 50, 100, 15), "Task Name");
                taskMessage = GUI.TextField(new Rect(rect.center.x - 90, rect.center.y - 30, 175, 20), taskMessage);
                GUI.Label(new Rect(rect.center.x - 90, (rect.center.y + 40) - 50, 100, 15), "Object To Find");
                isQuest = true;
                break;
        }
    }

    public bool ProcessEvents(Event e)
    {
        switch (e.type)
        {
            case EventType.MouseDown:
                if (e.button == 0)
                {
                    if (rect.Contains(e.mousePosition))
                    {
                        isDragged = true;
                        GUI.changed = true;
                        isSelected = true;
                        style = selectedNodeStyle;
                    }
                    else
                    {
                        GUI.changed = true;
                        isSelected = false;
                        style = defaultNodeStyle;
                    }
                }

                if (e.button == 1 && isSelected && rect.Contains(e.mousePosition))
                {
                    ProcessContextMenu();
                    e.Use();
                }
                break;

            case EventType.MouseUp:
                isDragged = false;
                break;

            case EventType.MouseDrag:
                if (e.button == 0 && isDragged)
                {
                    Drag(e.delta);
                    e.Use();
                    return true;
                }
                break;
        }
        if (isQuest == true)
        {
            toggleBool = GUI.Toggle(new Rect(rect.center.x - 90, (rect.center.y + 72.5f) - 50, 60, 15), toggleBool, "Points");
            //gameObjectBool = GUI.Toggle(new Rect(rect.center.x - 90, (rect.center.y + 55) - 50, 125, 15), gameObjectBool, "Find Gameobject");
            
        }
        if (toggleBool == true)
        {
            pointMessage = GUI.TextField(new Rect(rect.center.x - 90, rect.center.y + 40, 175, 20), pointMessage);
        }
        //if (gameObjectBool == true)
        //{
        //    Scene scene = SceneManager.GetActiveScene();
        //    scene.GetRootGameObjects(gameObjectsList);

        //    // iterate root objects and do something
        //    for (int i = 0; i < gameObjectsList.Count; ++i)
        //    {
        //        gameObjectCount++;
        //        GameObject gameObject = gameObjectsList[i];
        //        Debug.Log(gameObject.name);
        //        gameObjectsName[i] = gameObject.name;
        //    }
        //    isDoneSearching = true;
        //}
        return false;
    }

    void OnTools_OptimizeSelected()
    {
        // Do something!
    }
    void OnTools_Help()
    {
        Help.BrowseURL("http://example.com/product/help");
    }

    private void ProcessContextMenu()
    {
        GenericMenu genericMenu = new GenericMenu();
        genericMenu.AddItem(new GUIContent("Remove node"), false, OnClickRemoveNode);
        genericMenu.ShowAsContext();
    }

    private void OnClickRemoveNode()
    {
        if (OnRemoveNode != null)
        {
            OnRemoveNode(this);
            inPoint.attached = 0;
            outPoint.attached = 0;
        }
    }
}
