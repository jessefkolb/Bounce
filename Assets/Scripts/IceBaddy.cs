using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBaddy : MonoBehaviour {

    float increment;
    float time;
    bool movingPositive;
    bool rotate;
    public bool shark;
    public bool parrot;
    public bool parrot2;

    // Use this for initialization
    void Start () {
        increment = 0;
        time = 0;

        if (shark || parrot) movingPositive = true;
        else if (parrot2) movingPositive = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale != 0f)
        {
            if(shark || parrot || parrot2)
            {
                if (time >= 1.5)
                {
                    movingPositive = false;
                }

                if (time <= -1.5)
                {
                    movingPositive = true;

                }
            }

            else
            {
                if (time >= 1)
                {
                    movingPositive = false;
                }

                if (time <= -1)
                {
                    movingPositive = true;

                }
            }

            if (movingPositive)
            {
               if(shark || parrot || parrot2) time += 2* Time.deltaTime;
                else time += Time.deltaTime;
            }
            else
            {
                if(shark || parrot || parrot2) time -= 2 * Time.deltaTime;
                else time -= Time.deltaTime;
            }

            if(time >= -.05 && time <= .05)
            {

                if (movingPositive) rotate = false;
                else rotate = true;


                if(parrot || parrot2)
                {
                    if (rotate) transform.eulerAngles = new Vector3(0, -180, 0);
                    else transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    if (rotate) transform.eulerAngles = new Vector3(-180, 0, 0);
                    else transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }


            if(parrot || parrot2) transform.position = new Vector2((float)(GetComponent<Transform>().position.x + (time * 0.05)), GetComponent<Transform>().position.y);
            else transform.position = new Vector2(GetComponent<Transform>().position.x, (float)(GetComponent<Transform>().position.y + (time * 0.05)));

        }
    }
}
