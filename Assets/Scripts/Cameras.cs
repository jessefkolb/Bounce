using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour {

    public GameObject Player;
    public GameObject MainCamera;
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;
    public GameObject Camera5;
    public GameObject Camera6;
    public bool dynamicCam;
    float playerPositionX;
    float playerPositionY;

    public GameObject FixedCam;
    public GameObject TempCam;

    // Use this for initialization
    void Start ()
    {
        dynamicCam = true;
        MainCamera.SetActive(true);

        Camera1.SetActive(false);
        Camera2.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);
        Camera5.SetActive(false);
        Camera6.SetActive(false);
        FixedCam.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerPositionX = GetComponent<Transform>().position.x;
        playerPositionY = GetComponent<Transform>().position.y;

        if (Input.GetButtonDown("SwitchCamera"))
        {
            dynamicCam = !dynamicCam;
            CameraUpdate();
        }

        if(playerPositionX < -11)
        {
            TempCam = FixedCam;

            if (playerPositionY <= -28)
            {
                FixedCam = Camera1;
            }
            else if (playerPositionY < -6.5 && playerPositionY > -26.5)
            {
                FixedCam = Camera3;
            }
            else if (playerPositionY > -6.5)
            {
                FixedCam = Camera5;
            }

            CameraUpdate();
        }
        else if(playerPositionX > -11)
        {
            TempCam = FixedCam;
            if (playerPositionY <= -28)
            {
                FixedCam = Camera2;
            }
            else if (playerPositionY < -6.5 && playerPositionY > -26.5)
            {
                FixedCam = Camera4;
            }
            else if (playerPositionY > -6.5)
            {
                FixedCam = Camera6;
            }

            CameraUpdate();
        }

	}

    public void CameraUpdate()
    {
        if (dynamicCam)
        {
            MainCamera.SetActive(true);
            FixedCam.SetActive(false);
        }
        else
        {
            MainCamera.SetActive(false);
            TempCam.SetActive(false);
            FixedCam.SetActive(true);
        }
    }

}
