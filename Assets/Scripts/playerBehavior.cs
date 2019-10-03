using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{
    public float speed;

    public bool isJumping;
    public bool newRoom;

    private KeyCode right;
    private KeyCode left;
    private KeyCode jump;
    // Start is called before the first frame update
    void Start()
    {
        right = KeyCode.RightArrow;
        left = KeyCode.LeftArrow;
        jump = KeyCode.Space;
    }

    // Update is called once per frame
    void Update()
    {   
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
    }
    
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals("floor"))
        {
            isJumping = false;
        }
        if (col.gameObject.tag.Equals("wall"))
        {
            newRoom = true;
        }
    }
}
