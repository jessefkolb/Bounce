using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecover : MonoBehaviour {

    public GameObject UI;
    public GameObject Recovery;
    bool received;
    float timer;
    float timer2;

    private void Start()
    {
        timer = 1;
        timer2 = 1;
    }

    private void Update()
    {
        if(received)
        {
            timer -= Time.deltaTime;
            GetComponent<CircleCollider2D>().enabled = false;
            UI.SetActive(true);
            Recovery.SetActive(false);

            if (timer < 0)
            {
                timer2 -= Time.deltaTime;
                if(timer2 > 0) UI.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (float)(timer2));
            }
            if(timer2 < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.SendMessage("Recover");
            received = true;
        }
    }
}
