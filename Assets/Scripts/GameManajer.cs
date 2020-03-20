using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManajer : Singleton<GameManajer>
{

  
    public TowerButton ClikedBtn { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleEscape();
    }

    public void PickTower(TowerButton towerBtn)
    {
        this.ClikedBtn = towerBtn;
        Hover.Instance.Active(towerBtn.Sprite);
    }

    public void BuyTower()
    {
        Hover.Instance.Deactivate();
    }

    private void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.Deactivate();
        }
    }
}
