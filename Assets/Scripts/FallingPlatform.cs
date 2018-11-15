using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    // Use this for initialization

    float startTime;
    Vector2 position;
    bool hasFallen;

	void Start ()
    {
        startTime = 1;
        position = GetComponent<Transform>().position;
        hasFallen = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(hasFallen)
        {
            GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x, (float)(GetComponent<Transform>().position.y - 0.5));
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            startTime -= Time.deltaTime;
            if(startTime <= 0)
            {
                hasFallen = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        startTime = 1;
    }
}
