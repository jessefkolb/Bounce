using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Telescope : MonoBehaviour {

    public GameObject ScopeCamera;
    public GameObject PlayerCamera;

    public bool playerCam;


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
        		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(Input.GetButtonDown("Interact"))
            {
                playerCam = !playerCam;
            }
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetButton("Jump") || Math.Abs(Input.GetAxis("DPadHorizontal")) > 0f)
            {
                playerCam = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerCam = true;
    }
}
