using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

    int bounceCount;

	// Use this for initialization
	void Start () {
        bounceCount = 0;
	}

	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown (KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight); //Jump
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y); 
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -jumpHeight); //Barrels towards the ground to maintain bounce momentum
        }


        //This section of code is to avoid jittery bouncing

        if(bounceCount > 2)
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<CircleCollider2D>().enabled = true;
        }

        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Space))
        {
            bounceCount = 0;
        }


        Debug.Log("Bounce count: " + bounceCount);
        //If collide with ground 3 times, disable bounce until player presses space or S again. Aka, set for loop
        //with count, disable when count gets to 3, reset count when player bounces off new material or presses S or space
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            bounceCount++;
            Debug.Log("Accessed");
        }
    }
}
