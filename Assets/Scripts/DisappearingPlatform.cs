using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour {

    int bounces;

	// Use this for initialization
	void Start ()
    {
        bounces = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.gameObject.CompareTag("DisappearingPlatform1") && bounces == 1)
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
        else if (this.gameObject.CompareTag("DisappearingPlatform2") && bounces == 2)
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
        else if (this.gameObject.CompareTag("DisappearingPlatform3") && bounces == 3)
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }

    void Bounce ()
    {
        bounces++;
    }

    void Reset()
    {
        Debug.Log("Reset");
        transform.localScale = new Vector3(1, 1, 1);
        bounces = 0;
    }
}
