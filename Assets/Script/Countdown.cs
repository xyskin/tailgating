using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
    public bool isCount,clock;
    float time;
	// Use this for initialization
	void Start () {
        isCount = false;
        clock = false;
        time = 30.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (!isCount)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                isCount = true;
                clock = true;
            }
            this.GetComponent<Image>().fillAmount = time / 30;
        }

        if (isCount)
        {
            time += Time.deltaTime;
            if (time >= 30.0f)
            {
                isCount = false;
                clock = false;
            }
            this.GetComponent<Image>().fillAmount = 1 - time / 30;
        }
	}
}
