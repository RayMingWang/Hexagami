using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChooseTileHolder : TileHolder
{

    private bool[] move_state = new bool[3];
    ArrayList map = new ArrayList();
    private int currentplayer = 0;
    private bool[] recover_state = new bool[3];


    //private Token recover_token;
    void Start()
    {

        for (int i = 0; i < 3; i++)
        {
            map.Add(new ArrayList());
            move_state[i] = false;
        }

        add_tile(0, 1);
        add_tile(1, 2);
        add_tile(2, 3);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void leave_holder(int tag, int leavetarget, int arrivetarget)
    {
        
        ArrayList temp = (ArrayList)map[leavetarget];

        temp.Remove(temp[temp.Count - 1]);
        foreach (HexTile i in temp)
        {
            i.returntoTop();
        }
        move_state[arrivetarget] = false;
        move_state[leavetarget] = false;

        HexTile temp_tile = Tile_list[tag];
        if (temp_tile.token != null)
        {
            temp_tile.token.MoveToHexTile(arrivetarget, 1);
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
        if (temp_tile.fliped_by_player)
        {
            temp_tile.fliped_by_player = false;
            controller.FlipComplete();
        }

    }

    public void add_tile(int tag, int target)
    {
        
        ArrayList temp = (ArrayList)map[target];
        foreach (HexTile i in temp)
        {
            i.foldflat();
            i.getCovered();
        }

        temp.Add(Tile_list[tag]);
    }

    public void add_holder(int tag, int target)
    {
        
        ArrayList temp = (ArrayList)map[target];
        foreach (HexTile i in temp)
        {
            i.foldflat();
            i.getCovered();
        }
        move_state[Tile_list[tag].frontTarget] = true;
        move_state[Tile_list[tag].rearTarget] = true;
        temp.Add(Tile_list[tag]);
    }


    public bool check_under(int tag, int target)
    {
        ArrayList temp = (ArrayList)map[target];
        if (temp.Count != 0)
        {
            HexTile toptile = (HexTile)temp[temp.Count - 1];
            if (toptile.hex_tile_tag == tag)
                return true;
        }

        return false;
    }

    public bool check_moving(int front, int rear)
    {
        if (move_state[front] || move_state[rear])
        {
            return false;
        }


        return true;
    }

    public bool check_token(HexTile tile)
    {
        if (tile.token == null)
        {
            return false;
        }
        else
        {
            if (tile.token.token_tag != currentplayer)
            {
                return true;
            }
        }
        return false;
    }

    public float check_distant_token(Vector3 tile_position, int current_player)
    {
        return Vector3.Distance(tile_position, token_list[current_player].transform.position);
    }



    public HexTile Get_HexTile_by_Map(int target, int offset)
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

    public HexTile Get_HexTile_by_Token(int target)
    {
        return token_list[target].tile;
    }

    public void setCurrentPlayer(int player)
    {
        currentplayer = player;
    }
}

