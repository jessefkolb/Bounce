using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidetoSidePlatform : MonoBehaviour {

    float increment;
    float time;
    bool movingPositive;

	// Use this for initialization
	void Start ()
    {
        increment = 0;
        time = 0;
        if(this.gameObject.CompareTag("sidetoside1")) movingPositive = true;
        if (this.gameObject.CompareTag("sidetoside2")) movingPositive = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(time >= 2)
        {
            movingPositive = false;
        }

        if(time <= -2)
        {
            movingPositive = true;
        }

        if(movingPositive)
        {
            time += Time.deltaTime;
        }
        else
        {
            time -= Time.deltaTime;
        }

        transform.position = new Vector2((float)(GetComponent<Transform>().position.x + (time * 0.05)), GetComponent<Transform>().position.y);

	}
}
