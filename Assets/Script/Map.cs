using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour {
    public Image Moon, Sun;
    public GameObject Ra, Apep, birdclock, birdanticlock, bounce1, bounce2, bounce3, bounce4;
    public Countdown cd;
    public float angle;
    float[] a = new float[2];
    float[] b = new float[2];
    float[] c = new float[4];
    
	// Use this for initialization
	void Start () {
        angle = 0;
        Invoke("birdanti", 30.0f);
        Invoke("birdClock", 30.0f);
        Invoke("bounce", 60.0f);
    }

    // Update is called once per frame
    void Update() {
        if (!cd.GetComponent<Countdown>().clock)
        {
            Moon.transform.up = -Ra.transform.position;
            Sun.transform.up = -Apep.transform.position; // Zero
            angle = angle_360(Apep.transform.position, Ra.transform.position);
            Sun.GetComponent<Image>().fillClockwise = true;
            Sun.GetComponent<Image>().fillAmount =1- angle / 360; // Set angle
        }
        else
        {
            Moon.transform.up = -Ra.transform.position;
            Sun.transform.up = -Apep.transform.position; // Zero
            angle = angle_360(Apep.transform.position, Ra.transform.position);
            Sun.GetComponent<Image>().fillClockwise = false;
            Sun.GetComponent<Image>().fillAmount =angle / 360; // Set angle
        }
        //if (angle > 350) {; }
        //if (angle < 10) {; }
        if (isStart.isStr&&isStart.isexist)
        {
            SceneManager.UnloadSceneAsync("Day and night2");
            isStart.isexist = false;
        }
    }

    // Calculate angle
    float angle_360(Vector3 from_, Vector3 to_)
    {
        Vector3 v3 = Vector3.Cross(from_, to_);
        if (v3.z > 0)
            return Vector3.Angle(from_, to_);
        else
            return 360 - Vector3.Angle(from_, to_);
    }

    void birdanti()
    {
        for (int i = 0; i <= 1; i++)
        {
            a[i] = Random.Range(-6.24f, 6.24f);
            Instantiate(birdanticlock, new Vector3(a[i], Mathf.Sqrt((6.24f * 6.24f - a[i] * a[i])), 0), this.transform.rotation);
        }
    }

    void birdClock()
    {
        for (int i = 0; i <= 1; i++)
        {
            b[i] = Random.Range(-6.24f, 6.24f);
            Instantiate(birdclock, new Vector3(b[i], Mathf.Sqrt((6.24f * 6.24f - b[i] * b[i])), 0), this.transform.rotation);
        }
    }

    void bounce()
    {
        bounce1.GetComponent<BoxCollider2D>().enabled = true;
        bounce1.GetComponent<SpriteRenderer>().enabled = true;
        bounce1.GetComponentsInChildren<BoxCollider2D>()[0].enabled = true;
        //bounce1.GetComponentsInChildren<SpriteRenderer>()[0].enabled = true;
        bounce1.GetComponentsInChildren<BoxCollider2D>()[1].enabled = true;
        //bounce1.GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;

        bounce2.GetComponent<BoxCollider2D>().enabled = true;
        bounce2.GetComponent<SpriteRenderer>().enabled = true;
        bounce2.GetComponentsInChildren<BoxCollider2D>()[0].enabled = true;
        //bounce2.GetComponentsInChildren<SpriteRenderer>()[0].enabled = true;
        bounce2.GetComponentsInChildren<BoxCollider2D>()[1].enabled = true;
        //bounce2.GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;

        bounce3.GetComponent<BoxCollider2D>().enabled = true;
        bounce3.GetComponent<SpriteRenderer>().enabled = true;
        bounce3.GetComponentsInChildren<BoxCollider2D>()[0].enabled = true;
        //bounce3.GetComponentsInChildren<SpriteRenderer>()[0].enabled = true;
        bounce3.GetComponentsInChildren<BoxCollider2D>()[1].enabled = true;
        //bounce3.GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;

        bounce4.GetComponent<BoxCollider2D>().enabled = true;
        bounce4.GetComponent<SpriteRenderer>().enabled = true;
        bounce4.GetComponentsInChildren<BoxCollider2D>()[0].enabled = true;
        //bounce4.GetComponentsInChildren<SpriteRenderer>()[0].enabled = true;
        bounce4.GetComponentsInChildren<BoxCollider2D>()[1].enabled = true;
        //bounce4.GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;
    }
}
