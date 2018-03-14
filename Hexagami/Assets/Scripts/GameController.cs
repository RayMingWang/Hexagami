using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public TileHolder holder;
    int currentplayer=0;
    int flip_left = 3;

    private float Pause_between_move = 1.0f;
	// Use this for initialization

    public void FlipComplete()
    {
        if (currentplayer == 0)
        {
            flip_left--;
        }
        else
        {
            //StartCoroutine(PauseBetweenNPCMove());
            flip_left--;
        }




        if (flip_left == 0)
        {
            currentplayer++;
            if (currentplayer == 3)
                currentplayer = 0;
            holder.setCurrentPlayer(currentplayer);
            flip_left = 3;
        }
    }

    IEnumerator PauseBetweenNPCMove()
    {
        print(Time.time);
        yield return new WaitForSeconds(Pause_between_move);
        print(Time.time);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
