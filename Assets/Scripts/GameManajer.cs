using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManajer : Singleton<GameManajer>
{

  
    public TowerButton ClikedBtn { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickTower(TowerButton towerBtn)
    {
        this.ClikedBtn = towerBtn;
    }

    public void BuyTower()
    {
        ClikedBtn = null;
    }
}
