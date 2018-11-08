using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject projectileLeft;
    public GameObject projectileRight;
    public GameObject player;
	
	// Update is called once per frame
	void Update ()
    {
        Quaternion r = player.transform.rotation;

        float vx = player.transform.position.x;
        float vy = (float)(player.transform.position.y + 0.3);
        float vz = player.transform.position.z;


        if (Input.GetButtonDown("Shoot"))
        {
            if (player.GetComponent<playerControl>().direction == 1)
            {
                Instantiate(projectileRight, new Vector3(vx, vy, vz), r);
            }
            else
            {
                Instantiate(projectileLeft, new Vector3(vx, vy, vz), r);
            }            
        }
	}
}
