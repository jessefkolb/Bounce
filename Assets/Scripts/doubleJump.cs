using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleJump : MonoBehaviour {

    public bool hasDoubleJumped;
    public bool djAnim;
    public float t;
    public float t2;

    // Use this for initialization
    void Start ()
    {
        hasDoubleJumped = false;
        djAnim = false;
        t = (float)0.35;
        t2 = t;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if(GetComponent<playerControl>().grounded)
        {
            hasDoubleJumped = false;
            djAnim = false;
            t2 = t;
        }

        if (Input.GetButtonDown("Jump") && !hasDoubleJumped && !GetComponent<playerControl>().grounded) //if press space while in the air and the player has not used their double jump yet
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<playerControl>().jumpHeight); //Jump
            hasDoubleJumped = true;
            djAnim = true;
            GetComponent<playerControl>().sPress = false;
        }

        if(hasDoubleJumped && t2 > 0)
        {
            t2 -= Time.deltaTime;
            if(t2 <= 0)
            {
                djAnim = false;
                t2 = t;
            }
        }



    }
}
