using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeGun : MonoBehaviour {

    public GameObject projectileLeft;
    public GameObject projectileRight;
    public GameObject player;
    public Animator anim;

    float x;
    float y;
    public float angle;
    public bool usingStick;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion r = player.transform.rotation;

        float vx = player.transform.position.x;
        float vy = (float)(player.transform.position.y);
        float vz = player.transform.position.z;

        x = Input.GetAxis("Rhorizontal");
        y = Input.GetAxis("Rvertical");

        if (Mathf.Abs(x) >= 0.15f || Mathf.Abs(y) >= 0.15f)
        {

            Debug.Log("y: " + y);
            //Debug.Log("y: " + y);

            if ((player.GetComponent<BattleMode>().direction == 1 && y > 0) || (player.GetComponent<BattleMode>().direction == 2 && y < 0))
            {
                angle = (Mathf.Atan2(y, x) * Mathf.Rad2Deg) - 90;
            }
            transform.eulerAngles = new Vector3(0, 0, angle);
            usingStick = true;


            //Debug.Log(angle);

        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            usingStick = false;
        }

        anim.SetInteger("direction", player.GetComponent<BattleMode>().direction);
        anim.SetBool("usingStick", usingStick);

        if (Input.GetButtonDown("Shoot"))
        {
            if (player.GetComponent<BattleMode>().direction == 1)
            {
                GameObject PR = Instantiate(projectileRight, new Vector3((float)(vx + 0.5), vy, vz), r);
                PR.GetComponent<ProjectileRight>().angle = angle;
                PR.GetComponent<ProjectileRight>().usingStick = usingStick;
            }
            else
            {
                GameObject PL = Instantiate(projectileLeft, new Vector3((float)(vx - 0.5), vy, vz), r);
                PL.GetComponent<ProjectileLeft>().angle = angle;
                PL.GetComponent<ProjectileLeft>().usingStick = usingStick;
            }
        }
    }
}
