using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        isStart.isStr = false;
        isStart.cha1 = 0;
        isStart.cha2 = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.M))
        {
           
            isStart.isStr = true;
            SceneManager.LoadSceneAsync("Day and night");

            
        }
	}
}
