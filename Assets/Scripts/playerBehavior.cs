using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{
    public float speed;

    public bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.GetComponent<Transform>().Translate(new Vector3(speed, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.GetComponent<Transform>().Translate(new Vector3(-speed, 0));
        } 
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,7f), ForceMode2D.Impulse);
            isJumping = true;

        } 
    }
    
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals("floor"))
        {
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }
    }
}
