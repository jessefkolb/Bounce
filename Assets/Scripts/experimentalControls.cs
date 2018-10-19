using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class experimentalControls : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public double bounceHeight;

    private bool bounce;
    private bool sPress;

    private float debugX;
    private float debugY;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    // Use this for initialization
    void Start ()
    {
        bounceHeight = jumpHeight * 1.3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        debugX = GetComponent<Rigidbody2D>().velocity.x;
        debugY = GetComponent<Rigidbody2D>().velocity.y;


        if (Input.GetKey(KeyCode.D)) //right
        {

        }
        if (Input.GetKey(KeyCode.A)) //left
        {

        }
        if (Input.GetKey(KeyCode.Space)) //jump
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }
        if (Input.GetKeyDown(KeyCode.S)) //bounce
        {
            Debug.Log("Stuck in s");
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -jumpHeight);
            sPress = true;
        }
        if(bounce)
        {
            Debug.Log("Stuck in bounce");
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, (float)bounceHeight);
            bounce = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Accessed collision method");
        if (collision.CompareTag("Ground") && sPress)
        {
            bounce = true;
            sPress = false;
        }
    }
}
