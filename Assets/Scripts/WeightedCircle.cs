using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedCircle : MonoBehaviour
{

    private float Radius = 2f;

    private Vector2 _centre;
    private float _angle;

    public bool inRange;
    public GameObject Player;
    public float playerVelocity;
    public float playerForce;
    public float gravity;
    public float tensionForce;


    private void Start()
    {
        _angle = Mathf.PI/2;
        _centre = transform.position;
        gravity = Physics.gravity.y;
    }

    private void Update()
    {
        if (this.gameObject.CompareTag("wheel1")) Radius = (float)1.5f;
        if (this.gameObject.CompareTag("wheel2")) Radius = (float)1f;
        if (this.gameObject.CompareTag("wheel3")) Radius = (float).5f;

        if(inRange)
        {
            playerVelocity = Player.GetComponent<Rigidbody2D>().velocity.y;
            playerForce = playerVelocity * playerVelocity;

            tensionForce = (playerForce / Radius) - gravity;
            Debug.Log("Tension: " + tensionForce);

        }
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) inRange = false;
    }

}
