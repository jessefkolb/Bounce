using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMode : MonoBehaviour {

    public bool turnoff;
   
    public GameObject ground = null;
   
    public GameObject Gun = null;
    

    public float moveSpeed;
    public float jumpHeight;
    public double bounceHeight;
    public double tempBounceHeight;
    public bool idle;

    public bool bounce;
    public bool sPress;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;

    public int direction; //right is 1, left is 2


    public bool hasDoubleJump;
    public bool hasAirDash;
    public bool hasDashBomb;
    public bool hasGun;


    public bool hasDoubleJumped;
    public bool djAnim;
    public float t;
    public float t2;

    public bool airDashingCurrently;
    private bool hasAirDashed;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;

    public int totalHP;
    public int currentHP;

    private float immunityTimer;
    private bool justHit;

    public GameObject HUD;
    public GameObject Damage;
    public GameObject Enemy = null;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        //HEALTH

        totalHP = 5;

        immunityTimer = 2;
        currentHP = totalHP;

        //DOUBLE JUMP

        hasDoubleJumped = false;
        djAnim = false;
        t = (float)0.35;
        t2 = t;

        //AIR DASH

        dashTime = startDashTime;
        airDashingCurrently = false;


        bounceHeight = jumpHeight * 1.3;
        tempBounceHeight = bounceHeight;
        direction = 1; //Start facing right as the default
        anim = GetComponent<Animator>();
        idle = true;

        hasDoubleJump = true;
        hasAirDash = true;
        hasDashBomb = true;
        hasGun = true;

        Gun.SetActive(true);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); //Ground MUST be in "Ground" Layer
    }

    // Update is called once per frame
    void Update()
    {
       //BASIC MOVEMENT BEGIN

        if ((Input.GetKey(KeyCode.D) || Input.GetAxis("DPadHorizontal") > 0f) && !airDashingCurrently)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            direction = 1;
            idle = false;

        }

        if ((Input.GetKey(KeyCode.A) || Input.GetAxis("DPadHorizontal") < 0f) && !airDashingCurrently)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            direction = 2;
            idle = false;
        }

        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) && !airDashingCurrently)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetAxis("DPadHorizontal") == 0f && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight); //Jump
        }

        if (Input.GetButtonDown("Bounce"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -30); //Barrels towards the ground to maintain bounce momentum

            if (!grounded) sPress = true;
        }

        if (bounce)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, (float)bounceHeight);

            bounce = false;
            bounceHeight = tempBounceHeight;
        }

        //BASIC MOVEMENT END


        if (GetComponent<Rigidbody2D>().velocity.x == 0) idle = true;

        anim.SetBool("Grounded", grounded);
        anim.SetInteger("Direction", direction);
        anim.SetBool("Idle", idle);
        anim.SetBool("Bouncing", sPress);
        anim.SetBool("HasDashBomb", hasDashBomb);
        anim.SetBool("DashBomb", airDashingCurrently);
        anim.SetBool("DoubleJumping", djAnim);

//DOUBLE JUMP

        if (grounded)
        {
            hasDoubleJumped = false;
            djAnim = false;
            t2 = t;
        }

        if (Input.GetButtonDown("Jump") && !hasDoubleJumped && !grounded) //if press space while in the air and the player has not used their double jump yet
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight); //Jump
            hasDoubleJumped = true;
            djAnim = true;
            sPress = false;
        }

        if (hasDoubleJumped && t2 > 0)
        {
            t2 -= Time.deltaTime;
            if (t2 <= 0)
            {
                djAnim = false;
                t2 = t;
            }
        }

//AIR DASH

        if (grounded)
        {
            hasAirDashed = false;
        }

        if (Input.GetButtonDown("Dash") && !hasAirDashed && !grounded)
        {
            airDashingCurrently = true;
        }

        if (airDashingCurrently)
        {
            hasAirDashed = true;

            if (dashTime > 0)
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
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    GetComponent<Rigidbody2D>().gravityScale = 5;
                    dashTime = startDashTime;
                    airDashingCurrently = false;
                }
            }
        }

        //HEALTH

        if (justHit)
        {
            Damage.SetActive(true);
            Damage.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (float)(immunityTimer * 0.25));
            immunityTimer -= Time.deltaTime;
        }
        else
        {
            Damage.SetActive(false);
        }

        if (immunityTimer <= 0)
        {
            justHit = false;
            immunityTimer = 2;
        }

        if (currentHP <= 0)
        {
            //GameOver
            HUD.SendMessage("EndGame");
        }

        MenuDisplay.UpdateHealth(currentHP, totalHP);
    }

    void TakeDamage(int damage)
    {
        if (immunityTimer == 2)
        {
            if ((currentHP - damage) >= 0) currentHP -= damage;
            else currentHP = 0;
        }

        justHit = true;
    }

    void Recover()
    {
        if (currentHP < totalHP) currentHP++;
    }

    void AddHealth()
    {
        totalHP++;
        currentHP = totalHP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.CompareTag("Enemy")) && !sPress)
        {
            if (!hasDashBomb || !airDashingCurrently)
            {
                TakeDamage(1);
            }
        }

        else if (collision.CompareTag("Enemy"))
        {
            bounce = true;
        }

        if(collision.CompareTag("Special"))
        {
            collision.GetComponent<EdgeCollider2D>().enabled = false;
        }

        if (collision.CompareTag("deadzone")) currentHP = 0;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Special")) collision.GetComponent<EdgeCollider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Special")) && sPress)
        {
            bounce = true;
            sPress = false;
        }


    }

}
