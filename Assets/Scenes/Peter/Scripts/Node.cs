using System;
using UnityEditor;
using UnityEngine;

public enum NodeType {Dialog, Quest};

public class Node
{
    public Rect rect;
    public NodeType type;
    public string title;
    public bool toggleBool = false;
    public string diaMessage = "Enter message here";
    public string taskMessage = "Enter name here";
    public string pointMessage = "Enter point here";
    public bool isDragged;
    public bool isSelected;

    public EdgePoint inPoint;
    public EdgePoint outPoint;

    public GUIStyle style;
    public GUIStyle defaultNodeStyle;
    public GUIStyle selectedNodeStyle;

    public Action<Node> OnRemoveNode;

    public Node(Vector2 position, float width, float height, GUIStyle nodeStyle, GUIStyle selectedStyle, GUIStyle inPointStyle, GUIStyle outPointStyle, Action<EdgePoint> OnClickInPoint, Action<EdgePoint> OnClickOutPoint, Action<Node> OnClickRemoveNode, NodeType type)
    {
        rect = new Rect(position.x, position.y, width, height);
        style = nodeStyle;
        inPoint = new EdgePoint(this, EdgePointType.In, inPointStyle, OnClickInPoint);
        outPoint = new EdgePoint(this, EdgePointType.Out, outPointStyle, OnClickOutPoint);
        defaultNodeStyle = nodeStyle;
        selectedNodeStyle = selectedStyle;
        OnRemoveNode = OnClickRemoveNode;
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
                GUI.Label(new Rect(rect.center.x - 90, (rect.center.y + 10) - 50, 60, 15), "Message");
                GUI.Label(new Rect(rect.center.x - 20, (rect.center.y - 10) - 50, 50, 15), "Dialog");
                diaMessage = GUI.TextField(new Rect(rect.center.x - 90, rect.center.y - 25, 175, 20), diaMessage);
                break;

            case NodeType.Quest:
                GUI.Box(rect, title, style);
                GUI.Label(new Rect(rect.center.x - 20, (rect.center.y - 10) - 50, 50, 15), "Quest");
                GUI.Label(new Rect(rect.center.x - 90, (rect.center.y + 5) - 50, 100, 15), "Task Name");
                GUI.TextField(new Rect(rect.center.x - 90, rect.center.y - 30, 175, 20), taskMessage);
                GUI.Label(new Rect(rect.center.x - 90, (rect.center.y + 40) - 50, 100, 15), "Object To Find");
                object textField = GUI.TextField(new Rect(rect.center.x - 90, rect.center.y + 40, 175, 20), pointMessage);
                toggleBool = GUI.Toggle(new Rect(rect.center.x - 90, (rect.center.y + 72.5f) - 50, 60, 15), toggleBool, "Points");
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

        return false;
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
        }
    }
}
