using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class playerBehavior : MonoBehaviour
{
    public float speed;

    public bool isJumping;
    public bool newRoom;
    public bool newRoom2;
    public bool newRoom3;
    public bool ogRoom;

    public GameObject startText;

    public float timer = 60f;
    public GameObject timerText;

    public GameObject timerIcon;
    
    public ParticleSystem particles;

    private KeyCode right;
    private KeyCode left;
    private KeyCode jump;
    // Start is called before the first frame update
    void Start()
    {
        right = KeyCode.RightArrow;
        left = KeyCode.LeftArrow;
        jump = KeyCode.Space;
        startText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timer);
        if (timer <= 0)
        {
            SceneManager.LoadScene (1);
        }

        if (Input.anyKey)
        {
            startText.SetActive(false);
        }
        if (Input.GetKey(right))
        {
            this.GetComponent<Transform>().Translate(new Vector3(speed, 0));
        }

        if (Input.GetKey(left))
        {
            this.GetComponent<Transform>().Translate(new Vector3(-speed, 0));
        } 
        if (!isJumping && Input.GetKeyDown(jump))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,6f), ForceMode2D.Impulse);
            isJumping = true;

        }

        if (newRoom)
        {
            right = KeyCode.D;
            left = KeyCode.A;
            jump = KeyCode.W;
        }
        else if (ogRoom)
        {
            right = KeyCode.RightArrow;
            left = KeyCode.LeftArrow;
            jump = KeyCode.Space;
        }
        else if (newRoom2)
        {
            right = KeyCode.L;
            left = KeyCode.J;
            jump = KeyCode.I;
        }
        else if (newRoom3)
        {
            right = KeyCode.H;
            left = KeyCode.G;
            jump = KeyCode.LeftShift;
        }
    }
    
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals("floor"))
        {
            isJumping = false;
        }
        if (col.gameObject.tag.Equals("trigger1"))
        {
            newRoom = true;
            ogRoom = false;
            newRoom2 = false;
            newRoom3 = false;
        }
        if (col.gameObject.tag.Equals("spike"))
        {
            transform.position = new Vector3(-5f,-2f,0);
        }
        if (col.gameObject.tag.Equals("bug"))
        {
            transform.position = new Vector3(-5f,-2f,0);
        }
        if (col.gameObject.tag.Equals("trigger"))
        {
            ogRoom = true;
            newRoom = false;
            newRoom2 = false;
            newRoom3 = false;
        }
        if (col.gameObject.tag.Equals("trigger2"))
        {
            ogRoom = false;
            newRoom = false;
            newRoom2 = true;
            newRoom3 = false;
        }
        
        if (col.gameObject.tag.Equals("wall2"))
        {
            ogRoom = false;
            newRoom = false;
            newRoom2 = false;
            newRoom3 = true;
        }
        
        if (col.gameObject.tag.Equals("door"))
        {
            SceneManager.LoadScene (2);
        }
        if (col.gameObject.tag.Equals("timer"))
        {
            timer += 20f;
            particles.Play();
            timerIcon.SetActive(false);
        }
    }
}
