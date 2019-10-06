using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehavior : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset; 

    // Use this for initialization
    void Start () 
    {
        offset = new Vector3(3f, 2.5f, -10.1f);
        Debug.Log(offset);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        transform.position = player.transform.position + offset;
    }
}

