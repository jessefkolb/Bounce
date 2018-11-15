using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject projectileLeft;
    public GameObject projectileRight;
    public GameObject player;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        Quaternion r = player.transform.rotation;

        float vx = player.transform.position.x;
        float vy = (float)(player.transform.position.y);
        float vz = player.transform.position.z;

        anim.SetInteger("direction", player.GetComponent<playerControl>().direction);

        if (Input.GetButtonDown("Shoot"))
        {
            if (player.GetComponent<playerControl>().direction == 1)
            {
                Instantiate(projectileRight, new Vector3((float)(vx + 0.5), vy, vz), r);
            }
            else
            {
                Instantiate(projectileLeft, new Vector3((float)(vx - 0.5), vy, vz), r);
            }            
        }
	}

}
