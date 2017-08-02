using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shit : MonoBehaviour {
    float speed;
    AudioSource ashit;
	// Use this for initialization
	void Start () {
        speed = 5.0f;
        ashit = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, -speed * Time.deltaTime);
        this.GetComponent<Rigidbody2D>().AddForce(-this.transform.position * 10.0f);

      
    }

    
}
