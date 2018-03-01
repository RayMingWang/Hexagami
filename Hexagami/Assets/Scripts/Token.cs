using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour {
    public HexTile tile;
    public int token_tag;
    private Vector3 position_offset= new Vector3(0,-0.017f,0);

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = tile.transform.rotation;
        transform.position=tile.transform.position;

        if(tile.currentTarget == tile.frontTarget)
            transform.localPosition -= transform.rotation* position_offset;
        else
            transform.localPosition += transform.rotation * position_offset;

    }
}
