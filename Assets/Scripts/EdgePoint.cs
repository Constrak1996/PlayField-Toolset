﻿using System;
using UnityEngine;

public enum EdgePointType { In, Out }

public class EdgePoint
{
    public Rect rect;
    public EdgePointType type;
    public Node node;
    public GUIStyle style;
    public int attached = 0;
    public bool currentlyAttached = false;
    public Action<EdgePoint> OnClickEdgePoint;

    public EdgePoint(Node node, EdgePointType type, GUIStyle style, Action<EdgePoint> OnClickEdgePoint)
    {
        this.node = node;
        this.type = type;
        this.style = style;
        this.OnClickEdgePoint = OnClickEdgePoint;
        rect = new Rect(0, 0, 12.5f, 27.5f);
    }

    public void Draw()
    {
        rect.y = node.rect.y + (node.rect.height * 0.5f) - rect.height * 0.5f;

        switch (type)
        {
            case EdgePointType.In:
                rect.x = node.rect.x - rect.width + 8f;
                break;

            case EdgePointType.Out:
                rect.x = node.rect.x + node.rect.width - 8f;
                break;
        }

        if (GUI.Button(rect, "", style))
        {
            if (OnClickEdgePoint != null)
            {
                OnClickEdgePoint(this);
            }
        }
    }
}
