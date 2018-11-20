using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour {

    private float RotateSpeed = 4f;
    private float Radius = 2f;

    public GameObject vine1;
    public GameObject vine2;
    public GameObject vine3;


    Quaternion r;

    float vx;
    float vy;
    float vz;

    private Vector2 _centre;
    private float _angle;
    bool movingPositive;

    bool wait;
    float waitTimer;

    bool go;

    public GameObject Banana;

    private void Start()
    {
        _centre = transform.position;
        _angle = Mathf.PI / 2;
        waitTimer = 2;


        if (this.gameObject.CompareTag("wheel1")) { Radius = (float)1.5f; transform.eulerAngles = new Vector3(0, 0, (180 / Mathf.PI) * -_angle); }
        if (this.gameObject.CompareTag("wheel2")) { Radius = (float)1f; transform.eulerAngles = new Vector3(0, 0, (180 / Mathf.PI) * -_angle); }
        if (this.gameObject.CompareTag("wheel3")) { Radius = (float).5f; transform.eulerAngles = new Vector3(0, 0, (180 / Mathf.PI) * -_angle); }

        if (this.gameObject.CompareTag("Enemy")) InvokeRepeating("ThrowBanana", 2f, 2f);

        }

    private void Update()
    {
        r = transform.rotation;

        vx = transform.position.x;
        vy = (float)(transform.position.y);
        vz = transform.position.z;

        if (_angle >= Mathf.PI/2)
        {
            go = false;
            movingPositive = false;
            waitTimer -= Time.deltaTime; 
        }

        if(_angle <= -Mathf.PI/2)
        {
            go = false;
            movingPositive = true;
            waitTimer -= Time.deltaTime;
        }

        if(waitTimer <= 0)
        {
            go = true;
            waitTimer = 2;
        }

        if(go)
        {
            if (movingPositive)
            {
                if (this.gameObject.CompareTag("Enemy")) transform.eulerAngles = new Vector3(0, -180, 0);
                else transform.eulerAngles = new Vector3(0, 0, (180 / Mathf.PI) * -_angle);
                _angle += RotateSpeed * Time.deltaTime;
            }
            else
            {
                if (this.gameObject.CompareTag("Enemy")) transform.eulerAngles = new Vector3(0, 0, 0);
                else transform.eulerAngles = new Vector3(0, 0, (180 / Mathf.PI) * -_angle);
                _angle -= RotateSpeed * Time.deltaTime;
            }
        }
        

        var offset = new Vector2(-Mathf.Sin(_angle), -Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;

        

        
    }

    private void OnDisable()
    {
        if ((this.gameObject.CompareTag("Enemy")))
        {
           CancelInvoke("ThrowBanana");
            vine1.SetActive(false);
            vine2.SetActive(false);
            vine3.SetActive(false);
        }
    }

    void ThrowBanana()
    {
        Instantiate(Banana, new Vector3((float)(vx), vy, vz), r);
    }

}
