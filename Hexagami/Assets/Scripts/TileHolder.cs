﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHolder : MonoBehaviour {
    public HexTile[] Tile_list;
    ArrayList[] map = new ArrayList[18];
	// Use this for initialization
	void Start () {
        ArrayList holder = map[7];
        holder.Add(Tile_list[0]);


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
