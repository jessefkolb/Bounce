using System.Collections;
using System.Timers;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public double bounceHeight;

    public bool bounce;
    public bool sPress;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    public bool doubleJump;
    private bool notDoubleJumped;

    public bool airDash;
    private bool airDashingCurrently;
    private bool hasAirDashed;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction; //right is 1, left is 2

    public bool dashBomb;
    public bool miniGun;
        
    // Use this for initialization
    void Start ()
    {
        bounceHeight = jumpHeight * 1.3;
        direction = 1;

        doubleJump = true; //testing purposes, changing to false when adding power ups
        airDash = true;
        dashTime = startDashTime;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update ()
    {
        if (grounded)
        {
            notDoubleJumped = true;
            hasAirDashed = false;
        }
		
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            direction = 1;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            direction = 2;
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight); //Jump
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -jumpHeight); //Barrels towards the ground to maintain bounce momentum
            if (!grounded) sPress = true; 
        }

        if(bounce)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, (float)bounceHeight);
            bounce = false;
        }

        //Power ups

        if (doubleJump) //if the double jump powerup is enabled
        {
            if (Input.GetKeyDown(KeyCode.Space) && notDoubleJumped && !grounded) //if press space while in the air and the player has not used their double jump yet
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight); //Jump
                notDoubleJumped = false;
            }
        }

        if(airDash)
        {
            if (Input.GetKeyDown(KeyCode.X) && !hasAirDashed && !grounded)
            {
                airDashingCurrently = true; 
            }

            if(airDashingCurrently)
            {
                hasAirDashed = true;

                if(dashTime > 0)
                {
                    dashTime -= Time.deltaTime;

                    if (direction == 1)
                    {
                        GetComponent<Rigidbody2D>().gravityScale = 0;
                        GetComponent<Rigidbody2D>().velocity = new Vector2(dashSpeed, 0);
                    }
                    if (direction == 2)
                    {
                        GetComponent<Rigidbody2D>().gravityScale = 0;
                        GetComponent<Rigidbody2D>().velocity = new Vector2(-dashSpeed, 0);
                    }
                    if (dashTime <= 0)
                    {
                        GetComponent<Rigidbody2D>().gravityScale = 5;
                        dashTime = startDashTime;
                        airDashingCurrently = false;
                        Debug.Log("Entered");
                    }
                }            
            }
                       
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && sPress)
        {
            bounce = true;
            sPress = false;
        }
    }
}
