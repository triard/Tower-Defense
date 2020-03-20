using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{

    [SerializeField]
    private GameObject towerPrefabs;
    [SerializeField]
    private Sprite sprite;
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

   
    // Start is called before the first frame update

}
