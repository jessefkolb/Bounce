using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour {

    public GameObject Player;
    public GameObject MainCamera;
    public GameObject Camera1;
    public GameObject Camera2;
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

        if(playerPositionX < 7)
        {
            TempCam = FixedCam;
            FixedCam = Camera1;
            CameraUpdate();
        }
        else if(playerPositionX > 8)
        {
            TempCam = FixedCam;
            FixedCam = Camera2;
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
