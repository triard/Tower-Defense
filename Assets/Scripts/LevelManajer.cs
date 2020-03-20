﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManajer : MonoBehaviour
{

    [SerializeField]
    public GameObject[] tilePrefabs;

    [SerializeField]
    public CameraMovement cameraMovement;

    private Point BlueSpawn;
    private Point RedSpawn;
    [SerializeField]
    private GameObject bluePortalPrefabs;
    [SerializeField]
    private GameObject redPortalPrefabs;

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


    public void TestValue(Point p)
    {
        p.X = 3;
    }
    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, TileScript>();

        string[] mapData = ReadLevelText();

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

        newTile.SetUp(new Point(x, y), new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0));

        Tiles.Add(new Point(x, y), newTile);
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

        RedSpawn = new Point(10, 6);

        Instantiate(bluePortalPrefabs, Tiles[RedSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
    }
}
    