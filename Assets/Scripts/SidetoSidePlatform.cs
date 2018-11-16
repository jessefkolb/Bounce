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
        if(this.gameObject.CompareTag("sidetoside1") || this.gameObject.CompareTag("vertical1")) movingPositive = true;
        if (this.gameObject.CompareTag("sidetoside2") || this.gameObject.CompareTag("vertical2")) movingPositive = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Time.timeScale != 0f)
        {
            if (time >= 2)
            {
                movingPositive = false;
            }

            if (time <= -2)
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

            if (this.gameObject.CompareTag("sidetoside2") || this.gameObject.CompareTag("sidetoside1")) transform.position = new Vector2((float)(GetComponent<Transform>().position.x + (time * 0.05)), GetComponent<Transform>().position.y);
            if (this.gameObject.CompareTag("vertical2") || this.gameObject.CompareTag("vertical1")) transform.position = new Vector2(GetComponent<Transform>().position.x, (float)(GetComponent<Transform>().position.y + (time * 0.05)));

        }
        

    }
}
