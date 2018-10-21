using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBomb : MonoBehaviour {

    public GameObject currentWall = null;

	// Use this for initialization
		
	// Update is called once per frame
	void Update ()
    {
        if(currentWall && GetComponent<airDash>().airDashingCurrently)
        {
            currentWall.SendMessage("DestroyWall");
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("crackedWall"))
        {
            currentWall = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentWall = null;
    }

}
