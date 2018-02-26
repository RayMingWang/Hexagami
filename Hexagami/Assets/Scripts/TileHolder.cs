using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHolder : MonoBehaviour {
    public HexTile[] Tile_list;
    ArrayList[] map = new ArrayList[18];
	// Use this for initialization
	void Start () {
        add_holder(0,8);
        add_holder(1, 9);
        add_holder(2, 9);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void leave_holder(int tag, int target)
    {
        ArrayList temp = map[target];
        temp.Remove(temp.Count);
    }

    public void add_holder(int tag, int target)
    {
        ArrayList temp = map[target];
        if (temp.Count != 0)
        {
            HexTile toptile = (HexTile)temp[temp.Count];
            toptile.foldflat();
        }

        temp.Add(Tile_list[tag]);
    }

    public bool check_under(int tag, int target)
    {
        ArrayList temp = map[target];
        if (temp.Count != 0)
        {
            HexTile toptile = (HexTile)temp[temp.Count];
            if (toptile.hex_tile_tag == tag)
                return true;
        }
           
        return false;
    }
}
