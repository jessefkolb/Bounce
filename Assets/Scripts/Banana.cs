using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    float timer;

    // Use this for initialization
    void Start()
    {
        timer = 4;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
	
