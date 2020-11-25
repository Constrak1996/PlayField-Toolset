using System;
using UnityEditor;
using UnityEngine;

public class Edge
{
    public EdgePoint inPoint;
    public EdgePoint outPoint;
    public Action<Edge> OnClickRemoveEdge;

    public Edge(EdgePoint inPoint, EdgePoint outPoint, Action<Edge> OnClickRemoveEdge)
    {
        this.inPoint = inPoint;
        this.outPoint = outPoint;
        this.OnClickRemoveEdge = OnClickRemoveEdge;
    }

    public void Draw()
    {
        Handles.DrawBezier(
            inPoint.rect.center,
            outPoint.rect.center,
            inPoint.rect.center + Vector2.left * 50f,
            outPoint.rect.center - Vector2.left * 50f,
            Color.white,
            null,
            2f
        );

        if (Handles.Button((inPoint.rect.center + outPoint.rect.center) * 0.5f, Quaternion.identity, 4, 8, Handles.RectangleCap))
        {
            if (OnClickRemoveEdge != null)
            {
                OnClickRemoveEdge(this);
            }
        }
    }
}