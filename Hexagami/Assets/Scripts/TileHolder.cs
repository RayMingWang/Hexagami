using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHolder : MonoBehaviour {
    public HexTile[] Tile_list;
    public Token[] token_list;
    private bool[] move_state = new bool[20];
     ArrayList map =new ArrayList();
    // Use this for initialization

    private bool[] recover_state = new bool[3];

    //private Token recover_token;
	void Start () {

        for(int i = 0; i < 20; i++)
        {
            map.Add(new ArrayList());
            move_state[i] = false;
        }
        
        add_holder(0,8);
        add_holder(1, 9);
        add_holder(2, 9);

        add_holder(3, 11);
        add_holder(4, 6);
        add_holder(5, 15);
        add_holder(6, 2);
        add_holder(7,18);
        add_holder(8, 5);
        add_holder(9, 14);

        add_holder(10, 19);
        add_holder(11, 5);
        add_holder(12, 7);
        add_holder(13, 14);
        add_holder(14, 13);
        add_holder(15, 6);
        add_holder(16, 11);

        add_holder(17, 4);
        add_holder(18, 3);
        add_holder(19, 11);
        add_holder(20, 15);
        add_holder(21, 5);
        add_holder(22, 14);
        add_holder(23, 16);

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void leave_holder(int tag, int leavetarget,int arrivetarget)
    {
        ArrayList temp = (ArrayList)map[leavetarget];
        
        temp.Remove(temp[temp.Count-1]);
        foreach (HexTile i in temp)
        {
            i.returntoTop();
        }
        move_state[arrivetarget] = false;
        move_state[leavetarget] = false;

        HexTile temp_tile = Tile_list[tag];
        if (temp_tile.token != null)
        {
            temp_tile.token.MoveToHexTile(arrivetarget,1);
            temp_tile.token = null;
        }


        if (leavetarget == 9)
        {
            token_list[0].ResetTokenPosition();
        }

        if (leavetarget == 15)
        {
            token_list[1].ResetTokenPosition();
        }

        if (leavetarget == 6)
        {
            token_list[2].ResetTokenPosition();
        }

    }

    public void add_holder(int tag, int target)
    {
        ArrayList temp = (ArrayList)map[target];
        foreach (HexTile i in temp)
        {
            i.foldflat();
            i.getCovered();
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

    public bool check_moving(int front,int rear)
    {
        if(move_state[front]||move_state[rear])
        {
            return false;
        }

        move_state[front] = true;
        move_state[rear] = true;
        return true;
    }

    public HexTile Get_HexTile_by_Map(int target,int offset)
    {
        ArrayList temp = (ArrayList)map[target];
        if (temp.Count - offset <= 0)
            return null;
        else
            return (HexTile)temp[temp.Count - 1 - offset];
    }


    public HexTile Get_HexTile_by_Map(int target)
    {
        ArrayList temp = (ArrayList)map[target];
        if (temp.Count <= 0)
            return null;
        else
            return (HexTile)temp[temp.Count - 1];
    }
}
