using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour {

    public Transform playerCheck;
    public Vector2 playercheckradius;
    public LayerMask whatIsPlayer;
    float angle;


    private bool playerNear;
    public bool fall;
    private bool fade;
    public bool coconut;

    private Animator anim;
    private float timer;

    // Use this for initialization
    void Start ()
    {
        timer = 1;
        angle = 0;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        if(coconut) anim = GetComponent<Animator>();
	}

    void FixedUpdate()
    {
        playerNear = Physics2D.OverlapBox(playerCheck.position, playercheckradius, angle, whatIsPlayer); 
    }

    // Update is called once per frame
    void Update ()
    {
        if (playerNear) fall = true;

        if (fade && !coconut)
        {
            timer -= Time.deltaTime;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (float)timer);
            if (timer < 0.95)
            {
                fall = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            
        }
        else if(fade && coconut)
        {
            if(GetComponent<Rigidbody2D>() != null) Destroy(GetComponent<Rigidbody2D>());
            if(GetComponent<BoxCollider2D>() !=null) Destroy(GetComponent<BoxCollider2D>());
        }

        if (fall)
        {
            if(GetComponent<BoxCollider2D>() != null) GetComponent<Rigidbody2D>().gravityScale = 1;
        }


        if(timer <= 0) Destroy(this.gameObject);


        if(coconut)
        {
            anim.SetBool("fade", fade);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

        if(collision.CompareTag("Ground"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            fade = true;
        }
    }
}
