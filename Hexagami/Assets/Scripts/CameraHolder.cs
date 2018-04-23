using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour {
    public Transform camera_transform;
    public float horizental_speed= 10.0f;
    public float vertical_speed = 10.0f;

    public bool enable = false;
    public Vector2 origin_touch_point;
    [SerializeField]
    private float distance;
	// Use this for initialization
	void Start () {
        GetComponent<Animator>().enabled = false;
        distance = camera_transform.position.z;
    }

    // Update is called once per frame
    private void Update()
    {
        /*
        if (Input.GetMouseButton(0))
        {
            
            //camera_transform.position += new Vector3(0,0, distance);


            transform.eulerAngles = 
                new Vector3(Mathf.Clamp(transform.eulerAngles.x - vertical_speed * Input.GetAxisRaw("Mouse Y"),38,85),
                transform.eulerAngles.y + vertical_speed * Input.GetAxisRaw("Mouse X"), 0);
        }
    /*
        if (Input.GetKeyDown("w"))
        {
            distance += buchang;
            camera_transform.position = new Vector3(0, 0, distance);
        }
        if (Input.GetKeyDown("s"))
        {
            distance -= buchang;
            camera_transform.position = new Vector3(0, 0, distance);
        }
        */
    }
}
