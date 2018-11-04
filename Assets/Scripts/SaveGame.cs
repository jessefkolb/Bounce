using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour {

    public GameObject managerScript;

	public void Save()
    {
        playerControl script = managerScript.GetComponent<playerControl>();

        //Power Ups
        ES3.Save<bool>("hasDoubleJump", script.hasDoubleJump);
        ES3.Save<bool>("hasAirDash", script.hasAirDash);
        ES3.Save<bool>("hasDashBomb", script.hasDashBomb);
        Debug.Log("Saved");
    }
}
