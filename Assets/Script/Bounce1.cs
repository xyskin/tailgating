using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce1 : MonoBehaviour {
    int times;
    bool isBounce1,isBounce2;
	// Use this for initialization
	void Start () {
        times = 0;
        isBounce1 = false;
        isBounce2 = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Character"&&!isBounce1)
        {
            other.GetComponent<CharacterMove1>().speed = -0.8f * other.GetComponent<CharacterMove1>().speed;
            times++;
            Debug.Log(other.tag + " + " + times);
            isBounce1 = true;
            
        }
        if (other.tag == "Character2"&&!isBounce2)
        {
            other.GetComponent<CharacterMove2>().speed = -0.8f * other.GetComponent<CharacterMove2>().speed;
            isBounce2 = true;
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
