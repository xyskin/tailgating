using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMove2 : MonoBehaviour {
    public float speed;
   // float speedmax, speeda, speedb, speedmin;
    bool isJump, isShit;
    public Map map;
    public Image background, Apepwin;
    public Text text,ra, apep;
    public Bounce1 b1, b2, b3, b4;
    public Bounce2 c1, c2, c3, c4;
    bool isPress, isFirst;
    float count, t;
    
    // Use this for initialization
    void Start () {
        
        speed = 1.0f;
      //  speeda = 0.1f;
        //speedb = 10.0f;
        isJump = false;
        isShit = false;
        isPress = false;
        isFirst = false;
        t = 0;
        isStart.apep = false;
        
        //isStart.isStr = false;
        count = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(apep!=null)
        apep.GetComponent<Text>().text = isStart.cha2.ToString();
        count -= Time.deltaTime;
        this.GetComponent<Rigidbody2D>().AddForce(-this.transform.position * 10.0f);
        this.transform.up = this.transform.position;
        this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, speed * Time.deltaTime);
        if (!background.GetComponent<Countdown>().clock)
        {
            this.transform.localScale = new Vector3(0.15f, 0.15f, 1);
            if (speed < 0 && !b1.GetComponent<Bounce1>().i2 && !b2.GetComponent<Bounce1>().i2 && !b3.GetComponent<Bounce1>().i2 && !b4.GetComponent<Bounce1>().i2)
            {
                speed = -speed;
            }
            if (!isShit)
            {
                if (speed <= 50.0f)
                {
                    speed += 0.1f;
                }
            }
            else
            {
                if (speed >= 20.0f)
                {
                    speed -= 10.0f;
                }
            }
        }
        else
        {
            this.transform.localScale = new Vector3(-0.15f, 0.15f, 1);
            if (speed > 0 && !c1.GetComponent<Bounce2>().i2 && !c2.GetComponent<Bounce2>().i2 && !c3.GetComponent<Bounce2>().i2 && !c4.GetComponent<Bounce2>().i2)
            {
                speed = -speed;
            }
            if (!isShit)
            {
                if (speed >= -50.0f)
                {
                    speed -= 0.1f;
                }
            }
            else
            {
                if (speed <= -20.0f)
                {
                    speed += 10.0f;
                }
            }

            
        }
        if (isStart.cha2 >= 4)
        {
           
            Apepwin.GetComponent<Image>().enabled = true;
            ra.GetComponent<Text>().enabled = false;
            ra.GetComponentInChildren<Image>().enabled = false;
            apep.GetComponent<Text>().enabled = false;
            apep.GetComponentInChildren<Image>().enabled = false;
            text.GetComponent<Text>().enabled = true;
            Time.timeScale = 0;
            
        }

        //Character1
        if (((Input.GetKeyDown(KeyCode.P) && isStart.isStr) || (!isStart.isStr && isPress)) && !isJump)
        {
            isFirst = true;
            //Debug.Log(isJump);
            this.GetComponent<Rigidbody2D>().AddForce(this.transform.position * 200.0f);
            isPress = false;
            t= 1.0f;

        }
        if (Input.GetKey(KeyCode.P) && isFirst)
        {
            t -= Time.deltaTime;
            if (t >= 0)
                this.GetComponent<Rigidbody2D>().AddForce(this.transform.position * 5.0f);
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            isFirst = false;
        }

        if (count <= 0)
        {
            count = Random.Range(1.0f, 3.0f);
            isPress = true;
        }

    }

    //Enter
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.tag == "Building"||other.tag=="Shit")
        {
            //Debug.Log("Enter");
            isJump = false;
        }
        
        

        if (other.tag == "Shit")
        {
            isShit = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Character" && map.angle < 10 && !isStart.apep && isStart.cha2 <= 4)
        {
            if (isStart.cha2 <= 3)
            {
                //TO-DO
                //Apepwin.GetComponent<Image>().enabled = true;
                isStart.apep = true;
                isStart.cha2++;
                //Time.timeScale = 0;

                SceneManager.LoadSceneAsync("Day and night");
                //text.GetComponent<Text>().enabled = true;
            }
            else
            {
                isStart.cha1 = 0;
                isStart.cha2 = 0;
            }
        }
        
    }
       
    

    //Exit
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.tag == "Building")
        {
            //Debug.Log("Exit");
            isJump = true;
        }

        if (other.tag == "Shit")
        {
            isShit = false;
            Destroy(other.gameObject, 0.0f);
        }
    }

    
}
