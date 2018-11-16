using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingPlatforms : MonoBehaviour {

    float time;
    bool movingPositive;

    // Use this for initialization
    void Start ()
    {
        time = 0;
        bool movingPositive = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (time >= 2)
        {
            movingPositive = false;
        }

        if (time <= 0)
        {
            movingPositive = true;
        }

        if (movingPositive)
        {
            time += Time.deltaTime;
        }
        else
        {
            time -= Time.deltaTime;
        }

        transform.localScale = new Vector2((float)(time), GetComponent<Transform>().localScale.y);

    }
}
