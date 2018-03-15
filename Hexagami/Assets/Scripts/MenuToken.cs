using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToken : MonoBehaviour {

    public MenuHexTile tile;
    public int token_tag;
    private Vector3 position_offset = new Vector3(0, -0.25f, 0);

    // Use this for initialization
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {
        if (tile == null)
        {
            transform.position = new Vector3(0, -100, 0);
            return;
        }
        transform.rotation = tile.transform.rotation;
        transform.position = tile.transform.position;

        if (tile.currentTarget == tile.frontTarget)
            transform.localPosition -= transform.rotation * position_offset;
        else
            transform.localPosition += transform.rotation * position_offset;

    }


}
