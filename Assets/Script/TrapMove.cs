using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour {
    float speed;
    //int m;
    //bool isJump;
	// Use this for initialization
	void Start () {
        //GetComponent<Rigidbody2D>();
        speed = 15.0f;
        //m = 0;
       //isJump = false;
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody2D>().AddForce(-this.transform.position * 100000.0f);
        this.transform.right = this.transform.position;
        this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, -speed * Time.deltaTime);
        Debug.DrawRay(this.transform.position, -this.transform.right * 10.0f, Color.red);
        //if (speed <= 60.0f)
        //{
        //    m++;
        //    if (m == 30)
        //        m = 0;
        //        speed += 0.1f;
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (isJump == false)
        //    {
        //       //Debug.Log(isJump);
        //        this.GetComponent<Rigidbody2D>().AddForce(this.transform.position * 300.0f);
        //    }
        //}
	}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Ground")
    //    {
    //        //Debug.Log("Enter");
    //        isJump = false;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.tag == "Ground")
    //    {
    //        //Debug.Log("Exit");
    //        isJump = true;
    //    }
    //}
}
