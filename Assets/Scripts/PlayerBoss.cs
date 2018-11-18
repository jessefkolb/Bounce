using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoss : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject SecretCamera;

	// Use this for initialization
	void Start ()
    {
        MainCamera.SetActive(true);
        SecretCamera.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(GetComponent<Transform>().position.x >= 26.5)
        {
            SecretCamera.SetActive(true);
            MainCamera.SetActive(false);
        }
	}
}
