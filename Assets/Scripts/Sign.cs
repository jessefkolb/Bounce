using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour {

    public GameObject Canvas;
    public GameObject Hover;
    public bool active;
    public bool inrange;

    public bool hover;

    private void Start()
    {
        active = false;
    }

    private void Update()
    {
        Canvas.SetActive(active);

        if(inrange && Input.GetButtonDown("Interact")) active = !active;

        if (active) hover = false;
        else hover = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inrange = true;
            if(hover) Hover.SetActive(true);
            else Hover.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Canvas.SetActive(false);
            active = false;
            inrange = false;
            Hover.SetActive(false);

        }
    }
}
