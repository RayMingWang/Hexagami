using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public TileHolder holder;
    int currentplayer=0;
    int flip_left = 3;

    private float Pause_between_move = 1.8f;
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
            flip_left = 3;
        }
        if (currentplayer != 0)
        {
            StartCoroutine(PauseBetweenNPCMove());
            NPCFlip();
            
        }
    }

    IEnumerator PauseBetweenNPCMove()
    {
        //print(Time.time);
        yield return new WaitForSeconds(Pause_between_move);
        //print(Time.time);
    }

    void NPCFlip()
    {
        switch (flip_left)
        {
            case 3:
                break;
            case 1:
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
            if (80f - temp.NpcFlip_Check(currentplayer) > Random.Range(0.0f, 100f))
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
