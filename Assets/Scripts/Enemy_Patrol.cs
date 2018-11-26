using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol: MonoBehaviour {

 
    
    public bool isFlying = false;
    public bool isGround = false;
    public float speed;
    private bool right = true;
    public Transform detection;
    

    void Update()
    {

        if (isFlying)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D objectDetect = Physics2D.Raycast(detection.position, Vector2.right, .5f);
            if (objectDetect.collider == true)
            {
                if (right == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    right = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    right = true;
                }
            }
        }
        if (isGround)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D platformDetect = Physics2D.Raycast(detection.position, Vector2.down, 2);
            RaycastHit2D objectDetect = Physics2D.Raycast(detection.position, Vector2.right, .1f);
            if (platformDetect.collider == false || objectDetect.collider == true && objectDetect.transform.tag != "Player")
            {
                if(right == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    right = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    right = true;
                }
            }
            
        }
        
    
    }

  
}

