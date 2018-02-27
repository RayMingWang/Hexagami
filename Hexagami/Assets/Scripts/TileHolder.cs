﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHolder : MonoBehaviour {
    public HexTile[] Tile_list;
     ArrayList map =new ArrayList();
	// Use this for initialization
	void Start () {

        for(int i = 0; i < 18; i++)
        {
            map.Add(new ArrayList());
        }

        add_holder(0,8);
        add_holder(1, 9);
        add_holder(2, 9);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void leave_holder(int tag, int target)
    {
        ArrayList temp = (ArrayList)map[target];
        temp.Remove(temp[temp.Count-1]);
        if (temp.Count != 0)
        {
            HexTile toptile = (HexTile)temp[temp.Count - 1];
            toptile.returntoTop();
        }
    }

    public void add_holder(int tag, int target)
    {
        ArrayList temp = (ArrayList)map[target];
        if (temp.Count != 0)
        {
            HexTile toptile = (HexTile)temp[temp.Count-1];
            toptile.foldflat();
            toptile.getCovered();
        }

        temp.Add(Tile_list[tag]);
    }

    public bool check_under(int tag, int target)
    {
        ArrayList temp = (ArrayList)map[target];
        if (temp.Count != 0)
        {
            HexTile toptile = (HexTile)temp[temp.Count-1];
            if (toptile.hex_tile_tag == tag)
                return true;
        }
           
        return false;
    }
}
