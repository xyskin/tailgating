using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour {
    public Image Moon, Sun;
    public GameObject Ra, Apep;
    float angle;
	// Use this for initialization
	void Start () {
        angle = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Moon.transform.up = -Apep.transform.position;
        Sun.transform.up = -Apep.transform.position;
        angle = angle_360(Apep.transform.position, Ra.transform.position);
        Sun.GetComponent<Image>().fillAmount = angle / 360;
    }

    float angle_360(Vector3 from_, Vector3 to_)
    {
        Vector3 v3 = Vector3.Cross(from_, to_);
        if (v3.z > 0)
            return Vector3.Angle(from_, to_);
        else
            return 360 - Vector3.Angle(from_, to_);
    }
}
