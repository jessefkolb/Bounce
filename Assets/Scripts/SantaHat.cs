using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaHat : MonoBehaviour {

    public GameObject FanMaster;

    float hatTimer;
    bool startTimer;
    float incrementDegrees;

    private void Start()
    {
        hatTimer = 3;
        incrementDegrees = 0;
    }

    // Update is called once per frame
    void Update ()
    {
	    if (FanMaster.GetComponent<Fan>().playerNear % 2 == 1 && FanMaster.GetComponent<Fan>().On)
        {
            startTimer = true;
        }

        if(startTimer)
        {
            hatTimer -= Time.deltaTime;
            if(hatTimer > 2) GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + (Time.deltaTime * 5), GetComponent<Transform>().position.y + (Time.deltaTime * 5), GetComponent<Transform>().position.z);
            else GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + (Time.deltaTime * 5), GetComponent<Transform>().position.y - (Time.deltaTime * 5), GetComponent<Transform>().position.z);

            transform.eulerAngles = new Vector3(0, 0, (incrementDegrees++) * 10);
        }

        if(hatTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
