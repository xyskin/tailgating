using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M)&&Time.timeScale==0)
        {
            SceneManager.LoadSceneAsync("Day and night2");
            SceneManager.UnloadSceneAsync("Day and night");
            isStart.isexist = true;
            isStart.isStr = false;
        }
	}
}
