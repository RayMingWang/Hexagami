using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freecame : MonoBehaviour {
    public float speed = 50.0f;
    public float rotate_speed = 10.0f;

    private Vector3 lastmouse = new Vector3(255,255,255);

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1))  //Moving mode
        {
            
            Cursor.visible = false;
             
            Cursor.lockState = CursorLockMode.Confined;
            
            //Rotate
            lastmouse = Input.mousePosition - lastmouse;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x - rotate_speed * lastmouse.y, transform.eulerAngles.y + rotate_speed * lastmouse.x, 0);

            


            //Movement


            Vector3 dir = new Vector3();
            if (Input.GetKey(KeyCode.W)) dir.z = 1.0f;
            if (Input.GetKey(KeyCode.S)) dir.z = -1.0f;
            if (Input.GetKey(KeyCode.A)) dir.x = -1.0f;
            if (Input.GetKey(KeyCode.D)) dir.x = 1.0f;

            transform.Translate(speed * dir * Time.deltaTime);
            
        }
        else //Selecting mode
        {
            Cursor.visible = true;
            
            Cursor.lockState = CursorLockMode.Confined;
        }

        lastmouse = Input.mousePosition;

    }
}
