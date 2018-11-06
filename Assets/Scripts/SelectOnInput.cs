using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

    public EventSystem es;
    public GameObject selectedObj;

    private bool buttonSelected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(((Math.Abs(Input.GetAxis("DPadVertical")) > 0) || Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) && buttonSelected == false)
        {
            buttonSelected = true;
            es.SetSelectedGameObject(selectedObj);
            Debug.Log("Accessed");
        }
	}

    private void OnDisable()
    {
        buttonSelected = false;
    }

}
