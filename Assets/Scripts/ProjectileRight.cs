using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRight : MonoBehaviour {


    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(20, 0, 0);
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, 0, 0);

        if(GetComponent<Rigidbody2D>().velocity.x < 18)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Damage Enemy
        Destroy(this.gameObject);
    }



}
