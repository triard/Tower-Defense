using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AStar
{
    public static Dictionary<Point, Node> nodes;
    private static void CreateNodes()
    {
        nodes = new Dictionary<Point, Node>();
        foreach(TileScript tile in LevelManajer.Instance.Tiles.Values)
        {
            nodes.Add(tile.GridPosition, new Node(tile));
        }
    }

    public static void GetPath(Point start, Point goal)
    {
        if (nodes == null)
        {
            CreateNodes();
        }

        HashSet<Node> openList = new HashSet<Node>();
        HashSet<Node> closeList = new HashSet<Node>();
        Node currentNode = nodes[start];
        openList.Add(currentNode);

        for (int x = -1 ;x <= 1; x++)
        {
            for(int y = -1; y <= 1; y++)
            {
                Point neighbourPos = new Point(currentNode.GridPosition.X - x, currentNode.GridPosition.Y - y);
                if (LevelManajer.Instance.InBounds(neighbourPos) && LevelManajer.Instance.Tiles[neighbourPos].WalkAble &&neighbourPos != currentNode.GridPosition)
                {

                    int gCost = 0;
                    if (Math.Abs(x - y) == 1)
                    {
                        gCost = 10;
                    }
                    else
                    {
                        gCost = 14;
                    }

                    Node neighbour = nodes[neighbourPos];
                    if (!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour);
                    }

                    neighbour.CalsValues(currentNode,nodes[goal], gCost);

                }
            }
        }

        openList.Remove(currentNode);
        closeList.Add(currentNode);

        GameObject.Find("AstarDebugger")
                  .GetComponent<AStarDebugger>()
                  .DebugPath(openList, closeList);
    }
}
