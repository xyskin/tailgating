using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove1 : MonoBehaviour {
    float speed;
    bool isJump, isShit;
    public Map map;
	// Use this for initialization
	void Start () {
        
        speed = 1.0f;
        isJump = false;
        isShit = false;
	}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isShit);
        this.GetComponent<Rigidbody2D>().AddForce(-this.transform.position * 10.0f);
        this.transform.up = this.transform.position;
        this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, speed * Time.deltaTime);
        if (!isShit)
        {
            if (speed <= 120.0f)
            {
                speed += 0.1f;
            }
        }
        else
        {
            if (speed >= 20.0f)
            {
                speed -= 10.0f;
            }
        }

        //Character1
        if (Input.GetKeyDown(KeyCode.Space) && !isJump )
        {

            //Debug.Log(isJump);
            this.GetComponent<Rigidbody2D>().AddForce(this.transform.position * 200.0f);
        }

    }

    //Enter
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.tag == "Building")
        {
            //Debug.Log("Enter");
            isJump = false;
        }

        if (other.tag == "Character"&& map.angle > 350)
        {
            //TO-DO
        }

        if (other.tag == "Shit")
        {
            isShit = true;
        }
    }

    //Exit
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.tag == "Building")
        {
            //Debug.Log("Exit");
            isJump = true;
        }

        if (other.tag == "Shit")
        {
            isShit = false;
            Destroy(other.gameObject, 0.0f);
        }
    }

    void OntriggerStay2D(Collider2D other)
    {
        
    }
}
