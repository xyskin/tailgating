using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {
    float speed;
    int times;
	// Use this for initialization
	void Start () {
        speed = 5.0f;
        times = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody2D>().AddForce(-this.transform.position * 10.0f);
        this.transform.up = this.transform.position;
        this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, -speed * Time.deltaTime);
        Debug.DrawRay(this.transform.position, -this.transform.up * 10.0f, Color.red);
    }

   
}
