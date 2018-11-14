using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour {

    int bounces;
    private Animator anim;

    // Use this for initialization
    void Start ()
    {
        bounces = 0;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (this.gameObject.CompareTag("DisappearingPlatform1") && bounces == 1)
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
        else if (this.gameObject.CompareTag("DisappearingPlatform2") && bounces == 2)
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
        else if (this.gameObject.CompareTag("DisappearingPlatform3") && bounces == 3)
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
        if(this.gameObject.CompareTag("DisappearingPlatform3") || this.gameObject.CompareTag("DisappearingPlatform2")) anim.SetInteger("Bounces", bounces);
        
    }

    void Bounce ()
    {
        bounces++;
    }

    void Reset()
    {
        Debug.Log("Reset");
        transform.localScale = new Vector3(1, 1, 1);
        bounces = 0;
    }
}
