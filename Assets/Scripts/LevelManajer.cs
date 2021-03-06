﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManajer : Singleton<LevelManajer>
{

    [SerializeField]
    public GameObject[] tilePrefabs;

    [SerializeField]
    public CameraMovement cameraMovement;

    [SerializeField]
    private Transform map;

    private Point BlueSpawn;
    private Point RedSpawn;

    [SerializeField]
    private GameObject bluePortalPrefabs;
    
    [SerializeField]
    private GameObject redPortalPrefabs;

    private Point mapSize;

    public Dictionary<Point, TileScript> Tiles { get; set; }

    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, TileScript>();

        string[] mapData = ReadLevelText();


        mapSize = new Point(mapData[0].ToCharArray().Length, mapData.Length);
        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 maxTile = Vector3.zero;

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for(int y = 0; y < mapY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();

            for(int x = 0; x < mapX; x++)
            {
               PlaceTile(newTiles[x].ToString(),x,y, worldStart);
            }
        }

        maxTile = Tiles[new Point(mapX - 1, mapY - 1)].transform.position;

        cameraMovement.SetLimits(new Vector3(maxTile.x+TileSize,maxTile.y-TileSize));

        SpawnPortals();
    }

    private void PlaceTile(string tileType ,int x,int y, Vector3 worldStart)
    {
        int tileIndex = int.Parse(tileType);

        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();

        newTile.SetUp(new Point(x, y), new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0), map);

       
    }

    private string[] ReadLevelText()
    {
        TextAsset bindData = Resources.Load("Level") as TextAsset;

        string data = bindData.text.Replace(Environment.NewLine, string.Empty);

        return data.Split('-');
    }

    private void SpawnPortals()
    {
        BlueSpawn = new Point(0, 0);

        Instantiate(bluePortalPrefabs, Tiles[BlueSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);

        RedSpawn = new Point(11, 6);

        Instantiate(redPortalPrefabs, Tiles[RedSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
    }

    public bool InBounds(Point position)
    {
        return position.X >= 0 && position.Y >= 0 && position.X<mapSize.X&& position.Y<mapSize.Y;
    } 
}
    