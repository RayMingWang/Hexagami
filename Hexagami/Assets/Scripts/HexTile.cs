using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour {
    public Transform parent;
    public int frontTarget;
    public int rearTarget;
    public int currentTarget;

    public float lookangle = 50.0f;
    public float lookOpenTime=0.7f;
    public float lookCloseTime = 0.4f;
    public float looktimer = 2.0f;
    private float looktimer_real=0;

    private bool mouseDown = false;
    private bool mouseUpStart = true;
	void Start () {
		
	}
    private void OnMouseEnter()
    {
        Debug.Log("Enter");
        looktimer_real = looktimer;
        mouseUpStart = false;
        mouseDown = true;
    }
    private void OnMouseExit()
    {
        Debug.Log("Exit");
        mouseUpStart = true;
        //mouseDown = false;

    }
    // Update is called once per frame
    void Update () {

        if (looktimer_real <= 0&&mouseDown)
            mouseDown = false;
        else
        {
            if (looktimer_real > 0&& mouseUpStart)
            {
                looktimer_real -= Time.deltaTime;
            }
        }

        float new_rotation=0f;
        float new_time=0f;
        float new_start = 0f;
        if (mouseDown)
        {
            if (frontTarget == currentTarget)
            {
                new_start = 0.0f;
                new_rotation = -lookangle;
                new_time = lookOpenTime;
                parent.eulerAngles = new Vector3(LookOpenLerpbyProgress(new_start, new_rotation, new_time, parent.eulerAngles.x, Time.deltaTime), 0, 0);
            }
            else
            {
                new_start = -180.0f;
                new_rotation = lookangle - 180.0f;
                new_time = lookOpenTime;
                parent.eulerAngles = new Vector3(LookOpenLerpbyProgress(new_start, new_rotation, new_time, parent.eulerAngles.x, Time.deltaTime), 0, 0);
            }
        }
        else
        {
            if (frontTarget == currentTarget)
            {
                new_start = -lookangle;
                new_rotation = 0.0f;
                new_time = lookCloseTime;
                parent.eulerAngles = new Vector3(LookCloseLerpbyProgress(new_start, new_rotation, new_time, parent.eulerAngles.x, Time.deltaTime), 0, 0);
            }
            else
            {
                new_start = lookangle - 180.0f;
                new_rotation = -180.0f;
                new_time = lookCloseTime;
                parent.eulerAngles = new Vector3(LookCloseLerpbyProgress(new_start, new_rotation, new_time, parent.eulerAngles.x, Time.deltaTime), 0, 0);
            }
        }
        
    }

    private float LookCloseLerpbyProgress(float start,float end,float time, float current,float deltaTime)
    {
        //Debug.Log("current");
        if (current > 180f)
        {
            current -= 360f;
        }
        //Debug.Log(current);
        float speed_modifer= (0.4f +3.5f*(current - start) / (end-start));
        float new_current = current + speed_modifer * ((end-start) / time) * deltaTime;
        if (start > end)
        {
            if (new_current < end)
                new_current = end;
        }
        if (start < end)
        {
            if (new_current > end)
                new_current = end;
        }
        //Debug.Log("new_current");
        //Debug.Log(new_current);
        return new_current;

    }
    private float LookOpenLerpbyProgress(float start, float end, float time, float current, float deltaTime)
    {
        //Debug.Log("current");
        if (current > 180f)
        {
            current -= 360f;
        }
        //Debug.Log(current);
        float speed_modifer = (2f- 2f * (current - start) / (end - start));
        float new_current = current + speed_modifer * ((end - start) / time) * deltaTime;
        if (start > end)
        {
            if (new_current < end)
                new_current = end;
        }
        if (start < end)
        {
            if (new_current > end)
                new_current = end;
        }
        //Debug.Log("new_current");
        //Debug.Log(new_current);
        return new_current;

    }
}
