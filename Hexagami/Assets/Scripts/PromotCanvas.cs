using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromotCanvas : MonoBehaviour {
    public Canvas Pause_Menu;
    public GameObject Info_Menu;
    public GameObject Info_dismiss_bt;
    private bool Pause_state = false;
    private bool Info_state = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Active_Pause()
    {
        Pause_state = !Pause_state;
        Pause_Menu.gameObject.SetActive(Pause_state);
    }

    public void Active_Info()
    {
        //Debug.Log("???");
        Info_state = !Info_state;
        Info_Menu.SetActive(Info_state);
        Info_dismiss_bt.SetActive(Info_state);
    }

}
