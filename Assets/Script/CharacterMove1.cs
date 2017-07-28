using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove1 : MonoBehaviour {
    float speed;
    int m;
    bool isJump;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>();
        speed = 1.0f;
        m = 0;
        isJump = false;
	}

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().AddForce(-this.transform.position * 10.0f);
        this.transform.up = this.transform.position;
        this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, speed * Time.deltaTime);
        if (speed <= 120.0f)
        {
            m++;
            if (m == 30)
                m = 0;
            speed += 0.1f;
        }

        //Character1
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
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
    }

    //Exit
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.tag == "Building")
        {
            //Debug.Log("Exit");
            isJump = true;
        }
    }
}
