using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour {

    public GameObject managerScript;

    public void Load()
    {
        playerControl script = managerScript.GetComponent<playerControl>();

        //Power Ups (on player)
        ES3.Load<bool>("hasDoubleJump");
        ES3.Load<bool>("hasAirDash");
        ES3.Load<bool>("hasDashBomb");
        Debug.Log("Loaded");

        //Inventory

        //

    }
}
