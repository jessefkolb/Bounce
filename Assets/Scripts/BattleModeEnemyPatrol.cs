using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeEnemyPatrol : MonoBehaviour {

    public GameObject chute;

    public float speed;
    private bool right = true;
    public Transform detection;

    public RaycastHit2D platformDetect;
    public RaycastHit2D objectDetect;

    public bool collideSpecial;
    public bool dead;

    public bool collideGround;
    private Animator anim;


    public bool walkOff;

    public float v;
    int random;

    private void Start()
    {
        chute.SetActive(true);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        v = GetComponent<Rigidbody2D>().velocity.y;

        anim.SetBool("begin", collideSpecial);
        
        if (collideSpecial)
        {
           chute.SetActive(false);
           this.gameObject.GetComponent<PolygonCollider2D>().enabled = false; 
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = (float)0.5;
        }

        if(collideGround || walkOff)
        {
            this.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            platformDetect = Physics2D.Raycast(detection.position, Vector2.down, 2);
            objectDetect = Physics2D.Raycast(detection.position, Vector2.right, .1f);

        }

        if (platformDetect.collider == false && collideGround)
        {
            if (right == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                right = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                right = true;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Special"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v);
            collideSpecial = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            collideGround = true;
        }

        if(collision.CompareTag("Special"))
        {
            collideSpecial = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Special"))
        {
            collideSpecial = false;
        }
    }

}
