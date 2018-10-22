using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    bool doubleJumpMenu;
    bool airDashMenu;
    bool dashBombMenu;
    public GameObject canvas;

    void Start()
    {
        doubleJumpMenu = false;
        airDashMenu = false;
        dashBombMenu = false;
        canvas.SetActive(false);
    }

    void Update()
    {
        if(doubleJumpMenu)
        {
            canvas.SetActive(true);

            if (Input.GetButtonDown("Interact"))
            {
                doubleJumpMenu = false;
                this.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        if(airDashMenu)
        {
            canvas.SetActive(true);

            if (Input.GetButtonDown("Interact"))
            {
                airDashMenu = false;
                this.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        if(dashBombMenu)
        {
            canvas.SetActive(true);

            if (Input.GetButtonDown("Interact"))
            {
                dashBombMenu = false;
                this.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    void PowerUpAttained()
    {
        Time.timeScale = 0f;

        if (this.gameObject.CompareTag("DoubleJumpPowerUp"))
        {
            doubleJumpMenu = true;
        }
        else if (this.gameObject.CompareTag("AirDashPowerUp"))
        {
            airDashMenu = true;
        }
        else if (this.gameObject.CompareTag("DashBombPowerUp"))
        {
            dashBombMenu = true;
        }
    }
}
