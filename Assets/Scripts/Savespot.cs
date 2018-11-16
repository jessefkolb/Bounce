using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savespot : MonoBehaviour {

    public GameObject savedImage;
    public bool inTriggerRange;

    private void Start()
    {
        savedImage.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        if(inTriggerRange)
        {
            savedImage.SetActive(true);
        }
        else
        {
            savedImage.SetActive(false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inTriggerRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTriggerRange = false;
        }
    }

}
