using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBaddy : MonoBehaviour {

    float increment;
    float time;
    bool movingPositive;
    bool rotate;

    // Use this for initialization
    void Start () {
        increment = 0;
        time = 0;
        
        movingPositive = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale != 0f)
        {
            if (time >= 1)
            {
                movingPositive = false;
            }

            if (time <= -1)
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

            if(time >= -.01 && time <= .01)
            {
                rotate = !rotate;
                if(rotate)transform.eulerAngles = new Vector3(-180, 0, 0);
                else transform.eulerAngles = new Vector3(0, 0, 0);
            }


            transform.position = new Vector2(GetComponent<Transform>().position.x, (float)(GetComponent<Transform>().position.y + (time * 0.05)));

        }
    }
}
