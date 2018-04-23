using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PanHandler : MonoBehaviour
{
    public Transform cameraHolder;
    public float horizental_speed = 3.0f;
    public float vertical_speed = 3.0f;

    bool mousedown = false;
    Vector2 origin_touchpoint;
    Vector3 origin_cameraAngle;
    

    private void Start()
    {
        
    }



    private void OnMouseDown()
    {

        /*
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        start_angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        current_angle = transform.eulerAngles.z;
        Debug.Log(start_angle);
        */
        Debug.Log(Input.mousePosition);
        origin_touchpoint = Input.mousePosition;
        origin_cameraAngle = cameraHolder.eulerAngles;
        mousedown = true;
    }

    private void OnMouseExit()
    {

    }

    private void OnMouseUp()
    {
        mousedown = false;
    }


    void Update()
    {
        if (mousedown)
        {
            
            Vector2 mouseDifference = origin_touchpoint - (Vector2)Input.mousePosition;
            Debug.Log(mouseDifference);


            cameraHolder.eulerAngles =
                new Vector3(Mathf.Clamp(origin_cameraAngle.x + vertical_speed * mouseDifference.y, 38, 85)
                ,
                origin_cameraAngle.y + horizental_speed * mouseDifference.x
                , 
                0);

        
        }


    }
    /*
    private void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            transform.eulerAngles += new Vector3(0, 0, 16);
            Debug.Log(transform.eulerAngles.z);
        }
    }
    */

}
