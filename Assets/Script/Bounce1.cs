﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bounce1 : MonoBehaviour {
   // int times;
    public bool isBounce1,isBounce2;
    public bool i1,i2;
    public Image bg;
    public CharacterMove1 c1;
    public CharacterMove2 c2;
    float time;
    // Use this for initialization
    void Start () {
       // times = 0;
        isBounce1 = false;
        isBounce2 = false;
        i1 = i2 = false;
        
        
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if ((!bg.GetComponent<Countdown>().clock && c1.speed > 0&&time<=0)|| (bg.GetComponent<Countdown>().clock && c1.speed < 0&&time<=0))
        {
            i1 = false;
        }
        if ((!bg.GetComponent<Countdown>().clock && c2.speed > 0) || (bg.GetComponent<Countdown>().clock && c2.speed < 0))
        {
            i2 = false;
        }
    }
    
     void OnTriggerEnter2D(Collider2D other)
    {
        if (!bg.GetComponent<Countdown>().clock)
        {
            if (other.tag == "Character" && !isBounce1)
            {
                other.GetComponent<CharacterMove1>().speed = -20f;
                // times++;
                Debug.Log(other.tag);
                Debug.Log(other.GetComponent<CharacterMove1>().speed);
                isBounce1 = true;
                i1 = true;
                Debug.Log(i1);
                time = 1.0f;

            }
            if (other.tag == "Character2" && !isBounce2)
            {
                other.GetComponent<CharacterMove2>().speed = -20f;
                isBounce2 = true;
                i2 = true;
                
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Character" && isBounce1)
        {
            isBounce1 = false;
        }
        if (other.tag == "Character2" && isBounce2)
        {
            isBounce2 = false;
        }
    }
}
