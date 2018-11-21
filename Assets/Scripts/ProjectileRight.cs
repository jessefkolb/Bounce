using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRight : MonoBehaviour {

    public float angle;
    public bool usingStick;

    private void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;

        if(!usingStick)
            GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(20 * Mathf.Cos(angle * (Mathf.PI / 180)), 20 * Mathf.Sin(angle * (Mathf.PI / 180)));
        }
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Damage Enemy

        if(collision.CompareTag("Enemy") &&  collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.SendMessage("Die");
            Destroy(this.gameObject);
        }

        if(collision.CompareTag("Enemy") && collision.GetComponent<Icicle>() != null)
        {
            collision.GetComponent<Icicle>().fall = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player")) Destroy(this.gameObject);
    }
}
