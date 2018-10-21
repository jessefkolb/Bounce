using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleJump : MonoBehaviour {

    private bool hasDoubleJumped;

    // Use this for initialization
    void Start ()
    {
        hasDoubleJumped = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if(GetComponent<playerControl>().grounded)
        {
            hasDoubleJumped = false;
        }

        if (Input.GetButtonDown("Jump") && !hasDoubleJumped && !GetComponent<playerControl>().grounded) //if press space while in the air and the player has not used their double jump yet
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<playerControl>().jumpHeight); //Jump
            hasDoubleJumped = true;
        }
    }
}
