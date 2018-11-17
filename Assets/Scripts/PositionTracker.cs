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
            startingLocation = GetComponent<Transform>().position;
            ES3.Save<Vector3>("startingLocation", startingLocation, "StartingLocation_" + SceneManager.GetActiveScene().name + ".es3");
        }
    }
}
