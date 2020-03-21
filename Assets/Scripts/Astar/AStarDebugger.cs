using System.Collections;
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
}
