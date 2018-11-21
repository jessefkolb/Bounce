using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeEnemyPatrol : MonoBehaviour {

    public float speed;
    private bool right = true;
    public Transform detection;

    public RaycastHit2D platformDetect;
    public RaycastHit2D objectDetect;

    float timer;
    bool collideSpecial;

    public bool collideGround;
    private Animator anim;

    public float v;

    private void Start()
    {
        anim = GetComponent<Animator>();
        timer = (float)0.1;
    }

    void Update()
    {

        v = GetComponent<Rigidbody2D>().velocity.y;
        Debug.Log(v);

        anim.SetBool("begin", collideSpecial);
        if(collideSpecial)
        {
            timer -= Time.deltaTime;
            this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            if (timer <= 0)
            {
                this.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
                collideSpecial = false;
            }
        }

        if(collideGround)
        {
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, v);
            Debug.Log("JUST HIT " + v);
            collideSpecial = true;
            
        }
        if (collision.gameObject.CompareTag("Ground")) collideGround = true;
    }
}
