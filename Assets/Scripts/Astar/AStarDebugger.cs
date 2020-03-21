﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarDebugger : MonoBehaviour
{

    private TileScript start, goal;

    [SerializeField]
    public Sprite blankTile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CLickTale();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AStar.GetPath(start.GridPosition);
        }
    }

    private void CLickTale()
    {
        if (Input.GetMouseButtonDown(1)){ 
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null)
            {
                TileScript tmp = hit.collider.GetComponent<TileScript>();
                if (tmp != null)
                {
                    if (start == null)
                    {
                        start = tmp;
                        start.SpriteRenderer.sprite = blankTile;
                        start.SpriteRenderer.color = Color.green;
                        start.Debugging = true;
                    }
                    else if (goal == null)
                    {
                        goal = tmp;
                        goal.SpriteRenderer.sprite = blankTile;
                        goal.Debugging = true;
                        goal.SpriteRenderer.color = Color.red;
                    }
                }
            }
        }
    }
    public void DebugPath(HashSet<Node> openList)
    {
        foreach (Node node in openList)
        {
            node.TileRef.SpriteRenderer.color = Color.cyan;
            node.TileRef.SpriteRenderer.sprite = blankTile;
        }
    }
}
