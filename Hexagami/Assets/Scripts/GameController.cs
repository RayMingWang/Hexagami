using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public TileHolder holder;
    public PromotCanvas prompt;
    int currentplayer=0;
    int flip_left = 3;

    private float Pause_between_move = 0.8f;
	// Use this for initialization

    public void FlipComplete()
    {
        



        flip_left--;
        if (flip_left == 0)
        {
            currentplayer++;
            if (currentplayer == 3)
                currentplayer = 0;
            holder.setCurrentPlayer(currentplayer);
            prompt.SetFaction(currentplayer);
            flip_left = 3;
        }
        prompt.SetFold(flip_left);
        if (currentplayer != 0)
        {
            StartCoroutine(PauseBetweenNPCMove());
            
            
        }
    }

    IEnumerator PauseBetweenNPCMove()
    {
        //print(Time.time);
        yield return new WaitForSeconds(Pause_between_move);
        NPCFlip();
        //print(Time.time);
    }

    void NPCFlip()
    {
        switch (flip_left)
        {
            case 3:
                if (Random.value < 0.8)
                {
                    if (holder.Get_HexTile_by_Token(currentplayer) == null)
                    {
                        break;
                    }
                    int currentPosition=holder.Get_HexTile_by_Token(currentplayer).currentPosition();
                    if (holder.Get_HexTile_by_Map(currentPosition) == null)
                    {
                        break;
                    }
                    int currentTiletag = holder.Get_HexTile_by_Map(currentPosition).hex_tile_tag;
                    if (holder.Get_HexTile_by_Map(currentPosition).hex_tile_tag == currentTiletag)
                    {
                        holder.Get_HexTile_by_Token(currentplayer).NpcFlip();
                        return;
                    }
                }

                break;
            case 1:
                if (Random.value < 0.7)
                {
                    if (holder.Get_HexTile_by_Token(currentplayer) == null)
                    {
                        break;
                    }
                    int currentPosition = holder.Get_HexTile_by_Token(currentplayer).currentPosition();
                    if (holder.Get_HexTile_by_Map(currentPosition) == null)
                    {
                        break;
                    }
                    int currentTiletag = holder.Get_HexTile_by_Map(currentPosition).hex_tile_tag;
                    if (holder.Get_HexTile_by_Map(currentPosition).hex_tile_tag != currentTiletag)
                    {
                        holder.Get_HexTile_by_Token(currentplayer).NpcFlip();
                        return;
                    }
                }
                break;
            default:
                break;
        }
        while(true)
        {
            int i = (int)Random.Range(0.1f, 19.8f);
            HexTile temp = holder.Get_HexTile_by_Map(i);
            if (temp == null)
                continue;
            if (60f - temp.NpcFlip_Check(currentplayer) > Random.Range(0.0f, 100f))
            {
                temp.NpcFlip();
                break;
            }
                
        }
        //holder.token_list[currentplayer];
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
