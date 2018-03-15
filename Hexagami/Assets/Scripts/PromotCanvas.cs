﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromotCanvas : MonoBehaviour {
    public Canvas Pause_Menu;
    public GameObject Info_Menu;
    public GameObject Info_dismiss_bt;

    public Image FactionIcon;
    public Image FoldLeft;
    private bool Pause_state = false;
    private bool Info_state = false;
    private int Faction_set_state = 0;
    private int new_faction = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Faction_set_state==1)
        {
            FactionIcon.rectTransform.localScale -= new Vector3(Time.deltaTime*5f,0,0);
            if (FactionIcon.rectTransform.localScale.x<=0)
            {
                FactionIcon.sprite = Resources.Load<Sprite>("clan_" + new_faction.ToString());
                Faction_set_state = 2;
            }
            
        }
        if (Faction_set_state == 2)
        {
            FactionIcon.rectTransform.localScale += new Vector3(Time.deltaTime * 5f, 0, 0);
            if (FactionIcon.rectTransform.localScale.x >= 1)
            {
                FactionIcon.rectTransform.localScale = new Vector3(1,1,1);
                Faction_set_state = 0;
            }
        }
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

    public void SetFold(int i)
    {
        FoldLeft.sprite = Resources.Load<Sprite>("turnleft_"+i.ToString());
    }

    public void SetFaction(int i)
    {
        new_faction = i;
        Faction_set_state = 1;
    }

}
