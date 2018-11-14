using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlatform : MonoBehaviour {

    float startTime;
    float startTime2;
    bool isActive;

    // Use this for initialization
    void Start ()
    {
        isActive = true;
        startTime = 1;
        startTime2 = 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (isActive || startTime2 <= 0)
        {
            isActive = true;
            startTime2 = 1;
            transform.localScale = new Vector3(1, 1, 1);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, startTime);
        }
        else
        {
            startTime2 -= Time.deltaTime;
            transform.localScale = new Vector3(0, 0, 0);
        }

        if(startTime <= 0)
        {
            isActive = false;
            startTime = 1;
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            startTime -= Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startTime = 1;
        }
    }

}


