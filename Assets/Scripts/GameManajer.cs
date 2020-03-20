using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManajer : Singleton<GameManajer>
{
    [SerializeField]
    private GameObject towerPrefabs; 

    public GameObject TowerPrefabs
    {
        get
        {
            return towerPrefabs;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
