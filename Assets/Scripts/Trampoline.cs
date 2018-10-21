using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

    public bool onTrampoline;
    private Animator anim;

    // Use this for initialization
    void Start ()
    {
        onTrampoline = false;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetBool("OnTrampoline", onTrampoline);

        if (onTrampoline)
        {
            onTrampoline = false;
        }
	}

    void SetTrampolineTrue()
    {
        onTrampoline = true;
    }
}
