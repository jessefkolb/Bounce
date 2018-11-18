using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {

    public bool On;
    public GameObject Player;

    public float playerNear;
    private float xV;

    float timer;

    // Use this for initialization
    void Start ()
    {
        playerNear = 0;
        
        InvokeRepeating("Blow", 2f, 4f);
        if (this.gameObject.CompareTag("FanLeft")) xV = 20;
        if (this.gameObject.CompareTag("FanRight")) xV = -20;
        timer = 2;
    }

    // Update is called once per frame
    void Update ()
    {
        if (On)
        {
            timer -= Time.deltaTime;
        }

		if(On && playerNear%2 == 1)
        {
            Debug.Log("??");
            
            if (this.gameObject.CompareTag("FanLeft"))
            {
                Player.GetComponent<playerControl>().blow = true;
                Debug.Log("blow on");
            }
            
            if (this.gameObject.CompareTag("FanRight"))
            {
                Player.GetComponent<playerControl>().blowRight = true;
                Debug.Log("blowright on");
            }

            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(xV, Player.GetComponent<Rigidbody2D>().velocity.y);
        }

        else
        {
            if (this.gameObject.CompareTag("FanLeft")) Player.GetComponent<playerControl>().blow = false;
            if (this.gameObject.CompareTag("FanRight")) Player.GetComponent<playerControl>().blowRight = false;
        }

        if(timer <=0)
        {
            timer = 2;
            On = false;
        }

        
	}

    void Blow()
    {
        On = true;
    }
}
