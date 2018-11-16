using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlatform : MonoBehaviour {

    float startTime;
    float startTime2;
    bool isActive;
    bool inTriggerZone;

    // Use this for initialization
    void Start ()
    {
        isActive = true;
        startTime = 1;
        startTime2 = 2;

        inTriggerZone = false;
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
            inTriggerZone = false;
            startTime = 1;
        }

        if(inTriggerZone)startTime -= Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inTriggerZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTriggerZone = false;
            startTime = 1;
        }
    }

}


