using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMoveClockWise : MonoBehaviour {
    float speed;
    bool count;
    public float sec;
    public GameObject shit;
	// Use this for initialization
	void Start () {
        speed = 15.0f;
        count = false;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.up = this.transform.position;
        this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, -speed * Time.deltaTime);
        Debug.DrawRay(this.transform.position, -this.transform.up * 10.0f, Color.red);

        if (count == false)
        {
            sec = Random.Range(8.0f, 20.0f);
            count = true;
        }
        sec -= Time.deltaTime;
        if (sec <= 0)
        {
            count = false;
            Instantiate(shit, this.transform.position, this.transform.rotation);
            
        }
    }
}
