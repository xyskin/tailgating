using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMove1 : MonoBehaviour
{
    public float speed;
       
    bool isJump, isShit;
    public Map map;
    public Image background, Rawin;
    public Text text,ra,apep;
    public Bounce1 b1, b2, b3, b4;
    public Bounce2 c1, c2, c3, c4;
    bool isPress,isFirst;
    float count,t;
    // Use this for initialization
    void Start()
    {
        isFirst = false;
        speed = 1.0f;
        isJump = false;
        isShit = false;
        isPress = false;
        isStart.ra = false;
        //this.GetComponent<Animation>().Play();
        //isStart.isStr = false;
        count = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(ra!=null)
        ra.GetComponent<Text>().text = isStart.cha1.ToString();
        count -= Time.deltaTime;
        //Debug.Log(isShit);
        this.GetComponent<Rigidbody2D>().AddForce(-this.transform.position * 10.0f);
        this.transform.up = this.transform.position;
        this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.forward, speed * Time.deltaTime);
        if (!background.GetComponent<Countdown>().clock)
        {
            this.transform.localScale = new Vector3(0.15f, 0.15f, 1);
            if (speed < 0 && !b1.GetComponent<Bounce1>().i1 && !b2.GetComponent<Bounce1>().i1 && !b3.GetComponent<Bounce1>().i1 && !b4.GetComponent<Bounce1>().i1)
            {
                Debug.Log("Change speed");
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
            this.transform.localScale = new Vector3(-0.15f,0.15f, 1);
            if (speed > 0 && !c1.GetComponent<Bounce2>().i1 && !c2.GetComponent<Bounce2>().i1 && !c3.GetComponent<Bounce2>().i1 && !c4.GetComponent<Bounce2>().i1)
            {
                Debug.Log("Change");
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
        if (isStart.cha1 >=4)
        {
            
            Rawin.GetComponent<Image>().enabled = true;
            ra.GetComponent<Text>().enabled = false;
            ra.GetComponentInChildren<Image>().enabled = false;
            apep.GetComponent<Text>().enabled = false;
            apep.GetComponentInChildren<Image>().enabled = false;
            text.GetComponent<Text>().enabled = true;
            Time.timeScale = 0;
            
        }



        //Character1
        if (((Input.GetKeyDown(KeyCode.Space) && isStart.isStr) || (isPress && !isStart.isStr)) && !isJump)
        {

            //Debug.Log(isJump);
            this.GetComponent<Rigidbody2D>().AddForce(this.transform.position * 200.0f);
            isPress = false;
            isFirst = true;
            t = 1.0f;
        }
        if (Input.GetKey(KeyCode.Space)&&isFirst)
        {
            t -= Time.deltaTime;
            if (t >= 0)
                this.GetComponent<Rigidbody2D>().AddForce(this.transform.position * 5.0f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFirst = false;
        }

        if (count <= 0)
        {
            count = Random.Range(1.0f, 3.0f);
            isPress = true;
        }

        Debug.Log(speed);

    }

    //Enter
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.tag == "Building" || other.tag == "shit")
        {
            //Debug.Log("Enter");
            isJump = false;
            //Debug.Log(other.tag);
        }
       
        if (other.tag == "Shit")
        {
            isShit = true;
        }

        //if (other.tag == "Bounce")
        //{
        //    speed = -speed;
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(Time.time + other.name+ isStart.cha1);
       
            if (other.tag == "Character2" && map.angle > 350 && !isStart.ra && isStart.cha1 <= 4)
            {

                if (isStart.cha1 <= 3)
                {
                    //TO-DO
                    //Rawin.GetComponent<Image>().enabled = true;
                    isStart.ra = true;
                    isStart.cha1++;
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
