using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnding : MonoBehaviour {

    public bool forceIdle;
    Animator anim;
    

    // Use this for initialization
    void Start ()
    {
        forceIdle = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("ForceIdle", forceIdle);
    }
    
}
