using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airDash : MonoBehaviour {

    private bool airDashingCurrently;
    private bool hasAirDashed;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;

    // Use this for initialization
    void Start ()
    {
        dashTime = startDashTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(GetComponent<playerControl>().grounded)
        {
            hasAirDashed = false;
        }

        if (Input.GetButtonDown("Dash") && !hasAirDashed && !GetComponent<playerControl>().grounded)
        {
            airDashingCurrently = true;
        }

        if (airDashingCurrently)
        {
            hasAirDashed = true;

            if (dashTime > 0)
            {
                dashTime -= Time.deltaTime;

                if (GetComponent<playerControl>().direction == 1)
                {
                    GetComponent<Rigidbody2D>().gravityScale = 0;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(dashSpeed, 0);
                }
                if (GetComponent<playerControl>().direction == 2)
                {
                    GetComponent<Rigidbody2D>().gravityScale = 0;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-dashSpeed, 0);
                }
                if (dashTime <= 0)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    GetComponent<Rigidbody2D>().gravityScale = 5;
                    dashTime = startDashTime;
                    airDashingCurrently = false;
                }
            }
        }
    }
}
