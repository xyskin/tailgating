﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour {
    float speed;
    AudioSource a;
    //int m;
    //bool isJump;
	// Use this for initialization
	void Start () {
        //GetComponent<Rigidbody2D>();
        speed = 5.0f;
        a = GetComponent<AudioSource>();
        //m = 0;
        //isJump = false;
    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody2D>().AddForce(-this.transform.position * 1000.0f);
        this.transform.up = this.transform.position;
        this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, -speed * Time.deltaTime);
        Debug.DrawRay(this.transform.position, -this.transform.up * 10.0f, Color.red);
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

   

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.tag == "Ground")
    //    {
    //        //Debug.Log("Exit");
    //        isJump = true;
    //    }
    //}
}
