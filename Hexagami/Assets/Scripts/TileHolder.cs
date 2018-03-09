using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHolder : MonoBehaviour {
    public HexTile[] Tile_list;
    private bool[] move_state = new bool[20];
     ArrayList map =new ArrayList();
    // Use this for initialization

    private bool recover_state = false;
    private int recover_tag = 0;
    private int recover_tokentag;
    private Token recover_token;
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

    public void leave_holder(int tag, int target,int front,int rear)
    {
        ArrayList temp = (ArrayList)map[target];
        
        temp.Remove(temp[temp.Count-1]);
        foreach (HexTile i in temp)
        {
            i.returntoTop();
        }
        move_state[front] = false;
        move_state[rear] = false;


        //Handler of Manual Flip
        if (recover_state)
        {
            switch (recover_tokentag)
            {
                case 0:
                    temp = (ArrayList)map[8];
                    if (temp.Count != 0) { 
                        Tile_list[0].token = recover_token;
                        recover_token.tile = Tile_list[0];
                        recover_state = false;
                    }
                    else
                    {
                        temp = (ArrayList)map[9];
                        HexTile temptile = (HexTile)temp[temp.Count - 1];
                        temptile.ManualFlip();
                    }
                    break;
                case 1:
                    temp = (ArrayList)map[19];
                    if (temp.Count != 0)
                    {
                        Tile_list[10].token = recover_token;
                        recover_token.tile = Tile_list[10];
                        recover_state = false;
                    }
                    else
                    {
                        temp = (ArrayList)map[15];
                        HexTile temptile = (HexTile)temp[temp.Count - 1];
                        temptile.ManualFlip();
                    }
                    break;
                case 2:
                    temp = (ArrayList)map[3];
                    if (temp.Count != 0)
                    {
                        Tile_list[18].token = recover_token;
                        recover_token.tile = Tile_list[18];
                        recover_state = false;
                    }
                    else
                    {
                        temp = (ArrayList)map[6];
                        HexTile temptile = (HexTile)temp[temp.Count - 1];
                        temptile.ManualFlip();
                    }
                    break;
                default:
                    break;
            }
            return;
        }

        //for token Transfer
        int new_target;
        if (target == front)
        {
            new_target = rear;
        }
        else
        {
            new_target = front;
        }

        if (Tile_list[tag].token == null)
        {
            //Debug.Log("There is no token");
            return;

        }
        //There is tile under the token
        temp = (ArrayList)map[new_target];
        if (temp.Count >1)
        {
            HexTile newland = (HexTile)temp[temp.Count - 2];
            /*
            Tile_list[newland.hex_tile_tag].token = Tile_list[tag].token;
            Tile_list[tag].token.tile = Tile_list[newland.hex_tile_tag];
            Tile_list[tag].token = null;
            */
            if (newland.token == null)
            {
                newland.token = Tile_list[tag].token;
                Tile_list[tag].token.tile = newland;
                Tile_list[tag].token = null;
            }
            else
            {
                //token overlap
                Debug.Log("overlap");
                Token oldtoken = newland.token;
                newland.token = Tile_list[tag].token;
                Tile_list[tag].token.tile = newland;
                Tile_list[tag].token = null;
                switch (oldtoken.token_tag)
                {
                    case 0:
                        temp = (ArrayList)map[8];
                        if (temp.Count != 0)
                        {
                            Tile_list[0].token = Tile_list[tag].token;
                            Tile_list[tag].token.tile = Tile_list[0];
                            Tile_list[tag].token = null;


                        }
                        else
                        {

                            temp = (ArrayList)map[9];
                            HexTile temptile = (HexTile)temp[temp.Count - 1];
                            recover_tag = 9;
                            recover_token = Tile_list[tag].token;
                            Tile_list[tag].token = null;
                            recover_state = true;
                            recover_tokentag = 0;
                            temptile.ManualFlip();
                        }
                        break;

                    case 1:
                        temp = (ArrayList)map[19];
                        if (temp.Count != 0)
                        {
                            Tile_list[10].token = Tile_list[tag].token;
                            Tile_list[tag].token.tile = Tile_list[10];
                            Tile_list[tag].token = null;


                        }
                        else
                        {

                            temp = (ArrayList)map[15];
                            HexTile temptile = (HexTile)temp[temp.Count - 1];
                            recover_tag = 15;
                            recover_token = Tile_list[tag].token;
                            Tile_list[tag].token = null;
                            recover_state = true;
                            recover_tokentag = 1;
                            temptile.ManualFlip();
                        }
                        break;

                    case 2:
                        temp = (ArrayList)map[3];
                        if (temp.Count != 0)
                        {
                            Tile_list[18].token = Tile_list[tag].token;
                            Tile_list[tag].token.tile = Tile_list[18];
                            Tile_list[tag].token = null;


                        }
                        else
                        {

                            temp = (ArrayList)map[6];
                            HexTile temptile = (HexTile)temp[temp.Count - 1];
                            recover_tag = 6;
                            recover_token = Tile_list[tag].token;
                            Tile_list[tag].token = null;
                            recover_state = true;
                            recover_tokentag = 2;
                            temptile.ManualFlip();
                        }
                        break;
                    default:
                        break;
                }
            }
     
            
            
            
            
            

        }
        //token Fall into blank
        else
        {
            //if token land in a blank space
            Debug.Log("Reeeeeeeee");
            
            
            switch (Tile_list[tag].token.token_tag)
            {
                case 0:
                    temp = (ArrayList)map[8];
                    if (temp.Count != 0)
                    {
                        Tile_list[0].token = Tile_list[tag].token;
                        Tile_list[tag].token.tile = Tile_list[0];
                        Tile_list[tag].token = null;
                        
                        
                    }
                    else
                    {

                        temp = (ArrayList)map[9];
                        HexTile temptile = (HexTile)temp[temp.Count - 1];
                        recover_tag = 9;
                        recover_token = Tile_list[tag].token;
                        Tile_list[tag].token = null;
                        recover_state = true;
                        recover_tokentag = 0;
                        temptile.ManualFlip();
                    }
                    break;

                case 1:
                    temp = (ArrayList)map[19];
                    if (temp.Count != 0)
                    {
                        Tile_list[10].token = Tile_list[tag].token;
                        Tile_list[tag].token.tile = Tile_list[10];
                        Tile_list[tag].token = null;


                    }
                    else
                    {

                        temp = (ArrayList)map[15];
                        HexTile temptile = (HexTile)temp[temp.Count - 1];
                        recover_tag = 15;
                        recover_token = Tile_list[tag].token;
                        Tile_list[tag].token = null;
                        recover_state = true;
                        recover_tokentag = 1;
                        temptile.ManualFlip();
                    }
                    break;

                case 2:
                    temp = (ArrayList)map[3];
                    if (temp.Count != 0)
                    {
                        Tile_list[18].token = Tile_list[tag].token;
                        Tile_list[tag].token.tile = Tile_list[18];
                        Tile_list[tag].token = null;


                    }
                    else
                    {

                        temp = (ArrayList)map[6];
                        HexTile temptile = (HexTile)temp[temp.Count - 1];
                        recover_tag = 6;
                        recover_token = Tile_list[tag].token;
                        Tile_list[tag].token = null;
                        recover_state = true;
                        recover_tokentag = 2;
                        temptile.ManualFlip();
                    }
                    break;
                default:
                    break;
            }
                
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
}
