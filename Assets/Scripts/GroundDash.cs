using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDash : MonoBehaviour {

    private double dashTime;
    private double dashSpeed;
    private double moveSpeed;
    public bool dashingCurrently;

	// Use this for initialization
	void Start ()
    {
        dashTime = 0.5;
        moveSpeed = GetComponent<playerControl>().moveSpeed;
        dashSpeed = GetComponent<playerControl>().moveSpeed * 2;
        dashingCurrently = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if((Input.GetButtonDown("Dash") && GetComponent<playerControl>().grounded) || dashingCurrently)
        {
            dashingCurrently = true;

            if (Input.GetButtonDown("Dash")) dashTime = 0.5;

            if(dashTime > 0)
            {
                dashTime -= Time.deltaTime;
                GetComponent<playerControl>().moveSpeed = (float)dashSpeed;

                if (dashTime <= 0)
                {
                    Debug.Log("Reset");
                    dashTime = 0.5;
                    GetComponent<playerControl>().moveSpeed = (float)moveSpeed;
                    dashingCurrently = false;
                }
            }
        }
	}
}
