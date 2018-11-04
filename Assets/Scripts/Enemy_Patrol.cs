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

            RaycastHit2D platformDetect = Physics2D.Raycast(detection.position, Vector2.right, 3);
            if (platformDetect.collider == false)
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
            RaycastHit2D wallDetect = Physics2D.Raycast(detection.position, Vector2.right
                , 1);
            if (platformDetect.collider == false)
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

