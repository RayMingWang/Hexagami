using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour {
    public HexTile tile;
    public int token_tag;
    public TileHolder holder;
    private Vector3 position_offset= new Vector3(0,-0.017f,0);

	// Use this for initialization
	void Start () {


    }
	

	// Update is called once per frame
	void Update () {
        if (tile == null)
        {
            transform.position = new Vector3(0, -100, 0);
            return;
        }
        transform.rotation = tile.transform.rotation;
        transform.position=tile.transform.position;

        if(tile.currentTarget == tile.frontTarget)
            transform.localPosition -= transform.rotation* position_offset;
        else
            transform.localPosition += transform.rotation * position_offset;

    }

    public void MoveToHexTile(int target,int offset)
    {
        //tile = null;
        HexTile Tile_target = holder.Get_HexTile_by_Map(target,offset);
        
        //Fall into blank
        if (Tile_target == null)
        {
            tile = null;
            ResetTokenPosition();
            return;
        }
        //Fall on other token
        if (Tile_target.token != null)
        {
            Tile_target.token.tile = null;
            Tile_target.token.ResetTokenPosition();
            Tile_target.token = this;

            tile = Tile_target;
            tile.token = this;
            return;
        }
        else
        {
            tile = Tile_target;
            tile.token = this;
        }
    }



    public void ResetTokenPosition()
    {
        if (tile != null)
            return;
        switch (token_tag)
        {
            case 0:
                if(holder.Get_HexTile_by_Map(8)!= null)
                {
                    MoveToHexTile(8,0);
                }
                else
                {
                    holder.Get_HexTile_by_Map(9).ManualFlip();
                }
                break;
            case 1:
                if (holder.Get_HexTile_by_Map(19) != null)
                {
                    MoveToHexTile(19, 0);
                }
                else
                {
                    holder.Get_HexTile_by_Map(15).ManualFlip();
                }
                break;
            case 2:
                if (holder.Get_HexTile_by_Map(3) != null)
                {
                    MoveToHexTile(3, 0);
                }
                else
                {
                    holder.Get_HexTile_by_Map(6).ManualFlip();
                }
                break;
            default:
                break;
        }
    }
}
