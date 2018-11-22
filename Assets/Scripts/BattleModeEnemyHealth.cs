using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeEnemyHealth : MonoBehaviour {

    public bool dead;
    public bool monkey;
    public float deathTimer;
    public float updateKill;
    private Animator anim;

    private void Start()
    {
        updateKill = 0;
        deathTimer = 1;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(updateKill == 1)
        {
            MenuDisplay.UpdateKills();
        }

        if (dead)
        {
            updateKill++;
            if (monkey) GetComponent<Monkey>().enabled = false;
            transform.eulerAngles = new Vector3(-180, 0, 0);
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, (float)(GetComponent<Transform>().position.y - 0.05), GetComponent<Transform>().position.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
            GetComponent<SpriteRenderer>().color = new Color((float)0, 0, 0, deathTimer);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<BattleModeEnemyPatrol>().enabled = false;
            GetComponent<BattleModeEnemyPatrol>().chute.SetActive(false);
            anim.SetBool("dead", true);
            deathTimer -= Time.deltaTime;

        }
        if (deathTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Die()
    {
        dead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("deadzone"))
        {
            dead = true;
        }

        if(collision.CompareTag("projectile"))
        {
            dead = true;
        }

        if (collision.CompareTag("Player") && collision.gameObject.GetComponent<BattleMode>().sPress)
        {
            dead = true;
            //collision.gameObject.GetComponent<playerControl>().sPress = false;
        }

        else if (collision.CompareTag("Player") && collision.gameObject.GetComponent<BattleMode>().hasDashBomb && collision.GetComponent<BattleMode>().airDashingCurrently)
        {
            dead = true;
        }
    }
}
