using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public bool dead;
    public bool monkey;
    public float deathTimer;

    private void Start()
    {
        deathTimer = 1;
    }

    private void Update()
    {
        if(dead)
        {
            if (monkey) GetComponent<Monkey>().enabled = false;
            transform.eulerAngles = new Vector3(-180, 0, 0);
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, (float)(GetComponent<Transform>().position.y - 0.05), GetComponent<Transform>().position.z);
            GetComponent<SpriteRenderer>().color = new Color((float)0.5, 0, 0, deathTimer);
            GetComponent<BoxCollider2D>().enabled = false;
            deathTimer -= Time.deltaTime;

        }
        if(deathTimer <=0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Die()
    {
        dead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.gameObject.GetComponent<playerControl>().sPress)
        {
            dead = true;
            //collision.gameObject.GetComponent<playerControl>().sPress = false;
        }

        else if(collision.CompareTag("Player") && collision.gameObject.GetComponent<playerControl>().hasDashBomb && collision.GetComponent<airDash>().airDashingCurrently)
        {
            dead = true;
        }
    }
}
