using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManajer : Singleton<GameManajer>
{

  
    public TowerButton ClikedBtn { get; set; }
    
    private int currency;

    public int Currency {
        get
        {
           return currency;
        }
        set
        {
            this.currency = value;
            this.currencyTxt.text = value.ToString() + " <color=lime>Coins</color>";
        }
    }

    [SerializeField]
    private Text currencyTxt;
    // Start is called before the first frame update
    void Start()
    {
        Currency = 5; 
    }

    // Update is called once per frame
    void Update()
    {
        HandleEscape();
    }

    public void PickTower(TowerButton towerBtn)
    {
        if (Currency>=towerBtn.Price)
        {
            this.ClikedBtn = towerBtn;
            Hover.Instance.Active(towerBtn.Sprite);
        }

        
    }

    public void BuyTower()
    {
        if (Currency >= ClikedBtn.Price)
        {
            Currency -= ClikedBtn.Price;

            Hover.Instance.Deactivate();
        }
    }

    private void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.Deactivate();
        }
    }
}
