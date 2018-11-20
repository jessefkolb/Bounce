using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionTracker : MonoBehaviour {

    Vector3 startingLocation;
    string loc;

	// Use this for initialization
	void Start ()
    {
        if(!ES3.FileExists("LocationData_" + SceneManager.GetActiveScene().name + ".es3"))
        {
            //Saves the coordinates for the level selector
            startingLocation = GetComponent<Transform>().position;
            ES3.Save<Vector3>("startingLocation", startingLocation, "StartingLocation_" + SceneManager.GetActiveScene().name + ".es3");

            //Saves the coordinates for the campaign
            ES3.Save<Vector3>("Location", startingLocation, "LocationData_" + SceneManager.GetActiveScene().name + ".es3");
            ES3.Save<string>("Scene", SceneManager.GetActiveScene().name, "LocationData.es3");
            Debug.Log("Saved " + SceneManager.GetActiveScene().name);

        }
    }
}
