using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{

    [SerializeField]
    private GameObject towerPrefabs;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private int price;
    [SerializeField]
    private Text priceTxt; 
    public GameObject TowerPrefabs
    {
        get
        {
            return towerPrefabs;
        }
    }

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }

    public int Price { 
        get
        {
           return price;
        }
    }

    private void Start()
    {
        priceTxt.text = price + "Coins";
    }
}
