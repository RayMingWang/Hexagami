using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour {
    public Transform parent;
    public TileHolder holder;
    public Token token;
    public float yRotation;
    public int hex_tile_tag;
    public int frontTarget;
    public int rearTarget;
    public int currentTarget;


    //鼠标放上去查看用的
    public float lookangle = 50.0f;
    public float lookOpenTime = 0.7f;
    public float lookCloseTime = 0.4f;
    //---用来设置放下时间的
    public float looktimer = 2.0f;
    //---真正的Timer
    private float looktimer_real = 0;
    //鼠标放上去查看用的
    [SerializeField]
    private bool mouseEnter = false;
    [SerializeField]
    private bool mouseUpStart = true;

    //鼠标点进去的
    public float fliptime = 0.5f;
    [SerializeField]
    private bool mouseDown = false;

    private float lastcurrent=-180f;
    void Start() {
        if (frontTarget == currentTarget)
            lastcurrent = 0f;
    }
    private void OnMouseEnter()
    {
        //GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
        if (!check_under())
            return;

        //Debug.Log("Enter");
        looktimer_real = looktimer;
        mouseUpStart = false;
        mouseEnter = true;
    }


    private void OnMouseExit()
    {
        
        if (!check_under())
            return;
            
        //Debug.Log("Exit");
        mouseUpStart = true;
        //mouseDown = false;

    }

    private void OnMouseDown()
    {
        if (!check_under())
            return;
        if (!holder.check_moving(frontTarget, rearTarget))
            return;
        if (currentTarget == rearTarget)
            holder.add_holder(hex_tile_tag,frontTarget);
        else
            holder.add_holder(hex_tile_tag, rearTarget);
        mouseDown = true;
    }



    // Update is called once per frame
    void Update() {
        float new_rotation = 0f;
        float new_time = 0f;
        float new_start = 0f;

        /*
        if (Input.GetKeyDown("w"))
        {
            parent.eulerAngles = new Vector3(testlerp(parent.rotation.x) -150f, 0, 0);
        }
        */


        //When flip
        if (mouseDown)
        {
            if (frontTarget == currentTarget)
            {
                new_start = 0.0f;
                new_rotation = -180f;
                new_time = fliptime;
                parent.eulerAngles = new Vector3(FlipLerpbyProgress(new_start, new_rotation, new_time, parent.eulerAngles.x, Time.deltaTime), yRotation, 0);
            }
            else
            {
                new_start = -180.0f;
                new_rotation = 0f;
                new_time = fliptime;
                parent.eulerAngles = new Vector3(FlipLerpbyProgress(new_start, new_rotation, new_time, parent.eulerAngles.x, Time.deltaTime), yRotation, 0);
            }
            return;
        }

        // Look Timer Fire
        if (looktimer_real <= 0 && mouseEnter)
            mouseEnter = false;
        else
        {
            if (looktimer_real > 0 && mouseUpStart)
            {
                looktimer_real -= Time.deltaTime;
            }
        }


        //When higlihted;
        if (mouseEnter)
        {
            if (frontTarget == currentTarget)
            {
                new_start = 0.0f;
                new_rotation = -lookangle;
                new_time = lookOpenTime;
                parent.eulerAngles = new Vector3(LookOpenLerpbyProgress(new_start, new_rotation, new_time, parent.eulerAngles.x, Time.deltaTime), yRotation, 0);
            }
            else
            {
                new_start = -180.0f;
                new_rotation = lookangle - 180.0f;
                new_time = lookOpenTime;
                parent.eulerAngles = new Vector3(LookOpenLerpbyProgress(new_start, new_rotation, new_time, parent.eulerAngles.x, Time.deltaTime), yRotation, 0);
            }
        }
        else
        {
            if (frontTarget == currentTarget)
            {
                new_start = -lookangle;
                new_rotation = 0.0f;
                new_time = lookCloseTime;
                parent.eulerAngles = new Vector3(LookCloseLerpbyProgress(new_start, new_rotation, new_time, parent.eulerAngles.x, Time.deltaTime), yRotation, 0);
            }
            else
            {
                new_start = lookangle - 180.0f;
                new_rotation = -180.0f;
                new_time = lookCloseTime;
                parent.eulerAngles = new Vector3(LookCloseLerpbyProgress(new_start, new_rotation, new_time, parent.eulerAngles.x, Time.deltaTime), yRotation, 0);
            }
        }



    }



    private float LookCloseLerpbyProgress(float start, float end, float time, float current, float deltaTime)
    {
        //Debug.Log("current");
        if (current > 180f)
        {
            current -= 360f;
        }
        //Debug.Log(current);
        float speed_modifer = (0.4f + 3.5f * (lastcurrent - start) / (end - start));
        float new_current = lastcurrent + speed_modifer * ((end - start) / time) * deltaTime;
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
        lastcurrent = new_current;
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
        float speed_modifer = (2f - 2f * (lastcurrent - start) / (end - start));
        float new_current = lastcurrent + speed_modifer * ((end - start) / time) * deltaTime;
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
        lastcurrent = new_current;
        return new_current;

    }

    private float FlipLerpbyProgress(float start, float end, float time, float current, float deltaTime)
    {
        //Debug.Log("current");
        if (current > 180f)
        {
            current -= 360f;
        }
        //Debug.Log(current);

        
        //Debug.Log("speedmodifer");
        float speed_modifer = (0.4f + 1.5f * (lastcurrent - start) / (end - start));
        //Debug.Log(speed_modifer);
        float new_current = lastcurrent + speed_modifer * ((end - start) / time) * deltaTime;
        if (start > end)
        {
            if (new_current < end)
            {
                new_current = end;
                mouseDown = false;
                mouseEnter = false;
                mouseUpStart = true;
                currentTarget = rearTarget;
                holder.leave_holder(hex_tile_tag, frontTarget, rearTarget);
                



            }


        }
        if (start < end)
        {
            if (new_current > end)
            {
                new_current = end;
                mouseDown = false;
                mouseEnter = false;
                mouseUpStart = true;
                currentTarget = frontTarget;
                holder.leave_holder(hex_tile_tag, rearTarget, frontTarget);
                
            }

        }
        //Debug.Log("new_current");
        //Debug.Log(new_current);
        lastcurrent = new_current;
        return new_current;

    }

    private float testlerp(float current){
       //Debug.Log("rawcurrent");
        //Debug.Log(current);
        //Debug.Log("current");
        if (current > 180f)
        {
            current -= 360f;
        }
        //Debug.Log(current);
        return current;
    }

    private bool check_under()
    {
        //return false;
        return holder.check_under(hex_tile_tag,currentTarget);
    }

    public void foldflat()
    {
        mouseEnter = false;
    }

    public void getCovered()
    {
        transform.position -= new Vector3(0, 0.01f, 0);
    }

    public void returntoTop()
    {
        transform.position += new Vector3(0, 0.01f, 0);
    }

    public void ManualFlip()
    {
        /*
        if (!check_under())
            return;
        
        if (!holder.check_moving(frontTarget, rearTarget))
            return;
        */
        if (currentTarget == rearTarget)
            holder.add_holder(hex_tile_tag, frontTarget);
        else
            holder.add_holder(hex_tile_tag, rearTarget);
        mouseDown = true;
    }
}


