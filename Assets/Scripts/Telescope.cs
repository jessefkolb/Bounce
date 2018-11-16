using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Telescope : MonoBehaviour {

    public GameObject ScopeCamera;
    public GameObject PlayerCamera;

    public bool playerCam;
    bool inTriggerRange;


    // Use this for initialization
    void Start ()
    {
        playerCam = true;		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(playerCam)
        {
            PlayerCamera.SetActive(true);
            ScopeCamera.SetActive(false);
        }
        else
        {
            ScopeCamera.SetActive(true);
            PlayerCamera.SetActive(false);
        }

        if(inTriggerRange)
        {
            if (Input.GetButtonDown("Interact"))
            {
                playerCam = !playerCam;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetButton("Jump") || Math.Abs(Input.GetAxis("DPadHorizontal")) > 0f)
            {
                playerCam = true;
            }
        }
        		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inTriggerRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerCam = true;
        inTriggerRange = false;
    }
}
