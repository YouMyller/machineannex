﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileMap : MonoBehaviour {

    public Transform tilePrefab;
    public Vector2 mapSize;

    [Range(0,1)]
    public float outLinePercent;
	// Use this for initialization
	void Start ()
    {
        GenerateMap();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void GenerateMap()
    {
        string holderName = "Generated Map";
        if (transform.Find (holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y/2 + y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform; 
                newTile.localScale = Vector3.one * (1 - outLinePercent);
                newTile.parent = mapHolder;
            }
        }
    }
}
