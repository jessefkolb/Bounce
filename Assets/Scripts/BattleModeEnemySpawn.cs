using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeEnemySpawn : MonoBehaviour {


    Quaternion r;
    Quaternion r2;

    float vx;
    float vy;
    float vz;

    public bool rightSpawn;
    public bool middleSpawn;
    public bool leftSpawn;
   
    public GameObject Dog;

    float increment;


	// Use this for initialization
	void Start ()
    {
        if(rightSpawn) InvokeRepeating("EnemySpawn0", 6f, 9f);	
        if(middleSpawn) InvokeRepeating("EnemySpawn0", 3f, 9f);
        if(leftSpawn) InvokeRepeating("EnemySpawn0", 9f, 9f);

        r = transform.rotation;
        r2 = new Quaternion(0, 180, 0, 1);

        vx = transform.position.x;
        vy = (float)(transform.position.y);
        vz = transform.position.z;
    }
	
    void EnemySpawn0()
    {
        increment++;
        if (middleSpawn)
        {
            Instantiate(Dog, new Vector3((float)(vx), vy, vz), r);

        }
        else if (leftSpawn)
        {
            Instantiate(Dog, new Vector3((float)(vx), vy, vz), r);

        }
        else if (rightSpawn)
        {
            Instantiate(Dog, new Vector3((float)(vx), vy, vz), r2);

        } 
       
        if (increment == 3)
        {
            CancelInvoke("Enemy0");
            if (rightSpawn) InvokeRepeating("EnemySpawn0", 6f, 5f);
            if (middleSpawn) InvokeRepeating("EnemySpawn0", 3f, 5f);
            if (leftSpawn) InvokeRepeating("EnemySpawn0", 9f, 5f);
        }
    }

}
