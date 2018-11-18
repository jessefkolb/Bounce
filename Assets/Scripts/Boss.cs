using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    float deathTimer;

    float xtimer;
    bool bounce;
    bool bounceMeanly;
    bool bounceMeanlier;

    bool xtimerbool;

    float xVelocity;

    public Transform groundCheck;
    public float groundcheckradius;
    public LayerMask whatIsGround;
    public GameObject Door;

    bool movingLeft;
    bool hitWall;

    public int totalHP;
    public int currentHP;

    private float immunityTimer;
    private bool justHit;

    private bool grounded;
    public GameObject Damage;

    private bool second;
    private bool third;
    private Animator anim;

    float lastTimer;

    // Use this for initialization
    void Start ()
    {
        Door.SetActive(false);
        groundcheckradius = (float)0.1;
        xVelocity = 2;

        InvokeRepeating("Bounce", 2f, 3f);
        xtimer = (float)0.1;

        totalHP = 3;
        currentHP = 3;

        immunityTimer = 2;

        second = true;
        third = true;

        anim = GetComponent<Animator>();

        deathTimer = 4;
        lastTimer = 1;

    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundcheckradius, whatIsGround); //Ground MUST be in "Ground" Layer
    }

    // Update is called once per frame
    void Update ()
    {
        if (bounce)
        {
            if (movingLeft)
            {
                xVelocity = -2;
            }

            else
            {
                xVelocity = 2;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 10);
            xtimerbool = true;
            bounce = false;
        }

        else if(bounceMeanly)
        {
            if (movingLeft)
            {
                xVelocity = -4;
            }

            else
            {
                xVelocity = 4;
            }
            GetComponent<Rigidbody2D>().gravityScale = 3;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 15);
            xtimerbool = true;
            bounceMeanly = false;
        }
        else if(bounceMeanlier)
        {
            if (movingLeft)
            {
                xVelocity = -6;
            }

            else
            {
                xVelocity = 6;
            }

            GetComponent<Rigidbody2D>().gravityScale = 6;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 20);
            xtimerbool = true;
            bounceMeanlier = false;
        }

        if(xtimerbool)
        {
            xtimer -= Time.deltaTime;
        }

        if(xtimer <= 0)
        {
            xtimerbool = false;
            xtimer = (float)0.1;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, GetComponent<Rigidbody2D>().velocity.y);
        }

        if(grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }

        if(hitWall)
        {
            hitWall = false;
        }

        if (justHit)
        {
            if(!grounded) GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10);
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

            CancelInvoke("Bounce");
            GetComponent<CircleCollider2D>().enabled = false;

            if(grounded)
            {
                lastTimer -= Time.deltaTime;
                deathTimer -= Time.deltaTime;
            }
            
            if(deathTimer <= 0)
            {
                Door.SetActive(true);
                this.gameObject.SetActive(false);
            }
            
        }


        if(currentHP == 2 && second && grounded)
        {
            Debug.Log("Second");
            CancelInvoke("Bounce");
            InvokeRepeating("Bounce", 2f, 2f);
            second = false;
        }
        if(currentHP == 1 && third && grounded)
        {
            Debug.Log("Third");
            CancelInvoke("Bounce");
            InvokeRepeating("Bounce", 2f, 1f);
            third = false;
        }

        anim.SetBool("Grounded", grounded);
        anim.SetInteger("HP", currentHP);
        anim.SetFloat("lastTimer", lastTimer);

    }

    void Bounce()
    {
        if(currentHP == 3) bounce = true;
        if(currentHP == 2)
        {
            bounce = false;
            bounceMeanly = true;
        }
        if(currentHP == 1)
        {
            bounceMeanly = false;
            bounceMeanlier = true;
        }
    }

    void TakeDamage()
    {
        
        if ((currentHP - 1) >= 0) currentHP -= 1;
        else currentHP = 0;

        justHit = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<playerControl>().sPress && collision.gameObject.GetComponent<Transform>().position.y > GetComponent<Transform>().position.y + 2.8)
            {
                if (immunityTimer == 2) TakeDamage();
            }

            else
            {
                collision.gameObject.SendMessage("DisableInput");
                collision.gameObject.SendMessage("TakeDamage", 1);
                if(collision.gameObject.GetComponent<Transform>().position.x < GetComponent<Transform>().position.x) collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
                else collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            }
        }

        if (collision.CompareTag("RightWall"))
        {  
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2, GetComponent<Rigidbody2D>().velocity.y);
            movingLeft = true;
        }

        if(collision.CompareTag("LeftWall"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2, GetComponent<Rigidbody2D>().velocity.y);
            movingLeft = false;
        }
    }

}
