using System.Collections;
using System.Timers;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public bool turnoff;
    public GameObject wall = null;
    private float debugX;
    private float debugY;

    public float moveSpeed;
    public float jumpHeight;
    public double bounceHeight;
    private bool idle;

    public bool bounce;
    public bool sPress;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;

    public int direction; //right is 1, left is 2

    public bool dashBomb;
    public bool miniGun;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        bounceHeight = jumpHeight * 1.3;
        direction = 1; //Start facing right as the default
        anim = GetComponent<Animator>();
        idle = true;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        if (turnoff && wall)
        {
            wall.SendMessage("destroyWall");
        }

        debugX = GetComponent<Rigidbody2D>().velocity.x;
        debugY = GetComponent<Rigidbody2D>().velocity.y;

        //BASIC MOVEMENT BEGIN

        if ((Input.GetKey(KeyCode.D) || Input.GetAxis("DPadHorizontal") > 0f) && !GetComponent<airDash>().airDashingCurrently)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            direction = 1;
            idle = false;
            Debug.Log("Velocity in right: " + GetComponent<Rigidbody2D>().velocity.x);
        }

        if ((Input.GetKey(KeyCode.A) || Input.GetAxis("DPadHorizontal") < 0f) && !GetComponent<airDash>().airDashingCurrently)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            direction = 2;
            idle = false;
            Debug.Log("Velocity in left: " + GetComponent<Rigidbody2D>().velocity.x);
        }

        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) && !GetComponent<airDash>().airDashingCurrently)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            idle = true;
            Debug.Log("Velocity in horizontal movement key up: " + GetComponent<Rigidbody2D>().velocity.x);
        }

        if(Input.GetAxis("DPadHorizontal") == 0f && !GetComponent<airDash>().airDashingCurrently && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            idle = true;
            Debug.Log("Velocity in horizontal dpad key up: " + GetComponent<Rigidbody2D>().velocity.x);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight); //Jump
            Debug.Log("Velocity in jump: " + GetComponent<Rigidbody2D>().velocity.x);
        }

        if (Input.GetButtonDown("Bounce"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -30); //Barrels towards the ground to maintain bounce momentum
            Debug.Log("Velocity in buttondown bounce: " + GetComponent<Rigidbody2D>().velocity.x);
            if (!grounded) sPress = true;
        }

        if (bounce)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, (float)bounceHeight);
            Debug.Log("Velocity in bounce: " + GetComponent<Rigidbody2D>().velocity.x);
            bounce = false;
        }

        //BASIC MOVEMENT END

        anim.SetBool("Grounded", grounded);
        anim.SetInteger("Direction", direction);
        anim.SetBool("Idle", idle);

        Debug.Log("Velocity: " + GetComponent<Rigidbody2D>().velocity.x);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && sPress)
        {
            bounce = true;
            sPress = false;
        }

        if (collision.CompareTag("crackedWall"))
        {
            wall = collision.gameObject;
        }

    }
}
