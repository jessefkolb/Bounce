﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    bool doubleJumpMenu;
    bool airDashMenu;
    bool dashBombMenu;

    bool hasDoubleJump;
    bool hasAirDash;
    bool hasDashBomb;

    public GameObject canvas;
   // public GameObject PlayerControl;

    void Start()
    {
        doubleJumpMenu = false;
        airDashMenu = false;
        dashBombMenu = false;
        canvas.SetActive(false);

        if (ES3.FileExists("SaveData.es3"))
        {
            hasDoubleJump = ES3.Load<bool>("hasDoubleJump");
            hasAirDash = ES3.Load<bool>("hasAirDash");
            hasDashBomb = ES3.Load<bool>("hasDashBomb");
        }
        else
        {
            hasDoubleJump = false;
            hasAirDash = false;
            hasDashBomb = false;
        }
    }

    void Update()
    {
        if(doubleJumpMenu)
        {
            canvas.SetActive(true);

            if (Input.GetButtonDown("Interact"))
            {
                doubleJumpMenu = false;
                transform.localScale = new Vector3(0, 0, 0);
                Time.timeScale = 1f;
            }
        }
        if(airDashMenu)
        {
            canvas.SetActive(true);

            if (Input.GetButtonDown("Interact"))
            {
                airDashMenu = false;
                transform.localScale = new Vector3(0, 0, 0);
                Time.timeScale = 1f;
            }
        }
        if(dashBombMenu)
        {
            canvas.SetActive(true);

            if (Input.GetButtonDown("Interact"))
            {
                dashBombMenu = false;
                transform.localScale = new Vector3(0, 0, 0);
                Time.timeScale = 1f;
            }
        }

        if (this.gameObject.CompareTag("DoubleJumpPowerUp") && hasDoubleJump) transform.localScale = new Vector3(0, 0, 0);
        if (this.gameObject.CompareTag("AirDashPowerUp") && hasAirDash) transform.localScale = new Vector3(0, 0, 0);
        if (this.gameObject.CompareTag("DashBombPowerUp") && hasDashBomb) transform.localScale = new Vector3(0, 0, 0);

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
