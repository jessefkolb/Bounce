using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crackedWall : MonoBehaviour {

    public bool explode;
    private float disappear;
    private Animator anim;

    void Start()
    {
        explode = false;
        anim = GetComponent<Animator>();
        disappear = 3000;
    }

    private void Update()
    {
        anim.SetBool("Explode", explode);
    }

    // Use this for initialization
    public void DestroyWall()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        //GetComponent<SpriteRenderer>().enabled = false;
        explode = true;
        Debug.Log(explode);
    }
}
