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
}
