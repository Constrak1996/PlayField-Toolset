using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Threading;

public class DialogWindow : EditorWindow
{
    private List<Node> nodes;
    private List<Edge> edges;
    private object key = new object();

    int threadCounter = 0;
    int timer = 0;
    public List<Node> connectedNodes = new List<Node>();

    private GUIStyle nodeStyle;
    private GUIStyle selectedNodeStyle;
    private GUIStyle inPointStyle;
    private GUIStyle outPointStyle;

    private EdgePoint selectedInPoint;
    private EdgePoint selectedOutPoint;

    private Vector2 offset;
    private Vector2 drag;

    public bool isDone = false;

    [MenuItem("PlayField/Dialog Window")]
    private static void OpenWindow()
    {
        DialogWindow window = GetWindow<DialogWindow>();
        window.titleContent = new GUIContent("Dialog Window");
    }

    private void OnEnable()
    {
        nodeStyle = new GUIStyle();
        nodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1.png") as Texture2D;
        nodeStyle.border = new RectOffset(12, 12, 12, 12);

        selectedNodeStyle = new GUIStyle();
        selectedNodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1 on.png") as Texture2D;
        selectedNodeStyle.border = new RectOffset(12, 12, 12, 12);

        inPointStyle = new GUIStyle();
        inPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left.png") as Texture2D;
        inPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left on.png") as Texture2D;
        inPointStyle.border = new RectOffset(4, 4, 12, 12);

        outPointStyle = new GUIStyle();
        outPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right.png") as Texture2D;
        outPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right on.png") as Texture2D;
        outPointStyle.border = new RectOffset(4, 4, 12, 12);
    }

    private void OnGUI()
    {
        DrawGrid(20, 0.2f, Color.gray);
        DrawGrid(100, 0.4f, Color.gray);

        DrawNodes();
        DrawEdges();

        if (GUI.Button(new Rect(0, 0, 100, 25), "End Script"))
        {
            isDone = true;
            if (isDone == true)
            {
                CreateThreads();
                isDone = false;
            }
        }

        DrawEdgeLine(Event.current);

        ProcessNodeEvents(Event.current);
        ProcessEvents(Event.current);

        if (GUI.changed) Repaint();
    }

    private void CreateThreads()
    {
        Thread[] threads = new Thread[connectedNodes.Count];
        for (int i = 0; i < connectedNodes.Count; i++)
        {
            threads[i] = new Thread(() => TestRunOfAllNodes());
            threads[i].Name = i.ToString();

            threads[i].Start();
        }
    }

    private void TestRunOfAllNodes()
    {
        int j = 0;

        lock (key)
        {
            timer = 0;

            for (int i = 0; i < 1; i++)
            {
                if (connectedNodes[i].isDialog)
                {
                    foreach (char character in connectedNodes[i].diaMessage)
                    {
                        timer += 200;
                    }
                }
            }
            j = threadCounter;
            for (int i = threadCounter + 1; j < i; j++)
            {
                if (connectedNodes[j].isDialog)
                {
                    Debug.Log("Thread " + Thread.CurrentThread.Name + ":" + connectedNodes[j].diaMessage);
                    TaskGiver.loadedNodes.Add(connectedNodes[j]);
                }
                else if (connectedNodes[j].isQuest)
                {
                    Debug.Log("Thread " + Thread.CurrentThread.Name + " is quest node. \n Task name: " + connectedNodes[j].taskMessage + "\n Point is: " + connectedNodes[j].toggleBool + "\n Points is: " + connectedNodes[j].pointMessage);

                }
            }
            Thread.Sleep(timer);
        }
        threadCounter++;
    }

    private void DrawGrid(float gridSpacing, float gridOpacity, Color gridColor)
    {
        int widthDivs = Mathf.CeilToInt(position.width / gridSpacing);
        int heightDivs = Mathf.CeilToInt(position.height / gridSpacing);

        Handles.BeginGUI();
        Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);

        offset += drag * 0.5f;
        Vector3 newOffset = new Vector3(offset.x % gridSpacing, offset.y % gridSpacing, 0);

        for (int i = 0; i < widthDivs; i++)
        {
            Handles.DrawLine(new Vector3(gridSpacing * i, -gridSpacing, 0) + newOffset, new Vector3(gridSpacing * i, position.height, 0f) + newOffset);
        }

        for (int j = 0; j < heightDivs; j++)
        {
            Handles.DrawLine(new Vector3(-gridSpacing, gridSpacing * j, 0) + newOffset, new Vector3(position.width, gridSpacing * j, 0f) + newOffset);
        }

        Handles.color = Color.white;
        Handles.EndGUI();
    }

    private void DrawNodes()
    {
        if (nodes != null)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Draw();
            }
        }
    }

    private void DrawEdges()
    {
        if (edges != null)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                edges[i].Draw();
            }
        }
    }

    private void ProcessEvents(Event e)
    {
        drag = Vector2.zero;

        switch (e.type)
        {
            case EventType.MouseDown:
                if (e.button == 0)
                {
                    ClearEdgeSelection();
                }

                if (e.button == 1)
                {
                    ProcessContextMenu(e.mousePosition);
                }
                break;

            case EventType.MouseDrag:
                if (e.button == 0)
                {
                    OnDrag(e.delta);
                }
                break;
        }
    }

    private void ProcessNodeEvents(Event e)
    {
        if (nodes != null)
        {
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                bool guiChanged = nodes[i].ProcessEvents(e);

                if (guiChanged)
                {
                    GUI.changed = true;
                }
            }
        }
    }

    private void DrawEdgeLine(Event e)
    {
        if (selectedInPoint != null && selectedOutPoint == null)
        {
            Handles.DrawBezier(
                selectedInPoint.rect.center,
                e.mousePosition,
                selectedInPoint.rect.center + Vector2.left * 50f,
                e.mousePosition - Vector2.left * 50f,
                Color.white,
                null,
                2f
            );

            GUI.changed = true;
        }

        if (selectedOutPoint != null && selectedInPoint == null)
        {
            Handles.DrawBezier(
                selectedOutPoint.rect.center,
                e.mousePosition,
                selectedOutPoint.rect.center - Vector2.left * 50f,
                e.mousePosition + Vector2.left * 50f,
                Color.white,
                null,
                2f
            );

            GUI.changed = true;
        }
    }

    private void ProcessContextMenu(Vector2 mousePosition)
    {
        GenericMenu genericMenu = new GenericMenu();
        genericMenu.AddItem(new GUIContent("Dialog"), false, () => OnClickAddDialog(mousePosition));
        genericMenu.AddItem(new GUIContent("Quest"), false, () => OnClickAddQuest(mousePosition));
        genericMenu.ShowAsContext();
    }

    private void OnDrag(Vector2 delta)
    {
        drag = delta;

        if (nodes != null)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Drag(delta);
            }
        }

        GUI.changed = true;
    }

    private void OnClickAddDialog(Vector2 mousePosition)
    {
        if (nodes == null)
        {
            nodes = new List<Node>();
        }

        nodes.Add(new Node(mousePosition, 200, 150, nodeStyle, selectedNodeStyle, inPointStyle, outPointStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode, NodeType.Dialog, RemoveConnectedNode));
    }

    private void OnClickAddQuest(Vector2 mousePosition)
    {
        if (nodes == null)
        {
            nodes = new List<Node>();
        }

        nodes.Add(new Node(mousePosition, 200, 150, nodeStyle, selectedNodeStyle, inPointStyle, outPointStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode, NodeType.Quest, RemoveConnectedNode));
    }

    private void OnClickInPoint(EdgePoint inPoint)
    {
        selectedInPoint = inPoint;

        if (selectedOutPoint != null)
        {
            if (selectedOutPoint.node != selectedInPoint.node && inPoint.attached == 0 && selectedOutPoint.attached == 0)
            {
                inPoint.attached = 1;
                AddConnectedNode(selectedOutPoint.node);
                AddConnectedNode(selectedInPoint.node);
                CreateEdge();
                ClearEdgeSelection();
            }
            else
            {
                ClearEdgeSelection();
            }
        }
    }

    private void OnClickOutPoint(EdgePoint outPoint)
    {
        selectedOutPoint = outPoint;

        if (selectedInPoint != null)
        {
            if (selectedOutPoint.node != selectedInPoint.node && outPoint.attached == 0 && selectedInPoint.attached == 0)
            {
                outPoint.attached = 1;
                AddConnectedNode(selectedOutPoint.node);
                AddConnectedNode(selectedInPoint.node);
                CreateEdge();
                ClearEdgeSelection();
            }
            else
            {
                ClearEdgeSelection();
            }
        }
    }

    private void OnClickRemoveNode(Node node)
    {
        if (edges != null)
        {
            List<Edge> edgesToRemove = new List<Edge>();

            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].inPoint == node.inPoint || edges[i].outPoint == node.outPoint)
                {
                    edgesToRemove.Add(edges[i]);
                }
            }

            for (int i = 0; i < edgesToRemove.Count; i++)
            {
                edges.Remove(edgesToRemove[i]);
            }

            edgesToRemove = null;
        }

        nodes.Remove(node);
    }

    private void OnClickRemoveEdge(Edge edge)
    {
        edges.Remove(edge);
    }
    private void RemoveConnectedNode(Node node)
    {
        connectedNodes.Remove(node);
    }
    private void AddConnectedNode(Node node)
    {
        connectedNodes.Add(node);
        Debug.Log("Add connected node");
    }

    private void CreateEdge()
    {
        if (edges == null)
        {
            edges = new List<Edge>();
        }

        edges.Add(new Edge(selectedInPoint, selectedOutPoint, OnClickRemoveEdge, RemoveConnectedNode));
    }

    private void ClearEdgeSelection()
    {
        selectedInPoint = null;
        selectedOutPoint = null;
    }
}