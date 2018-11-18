using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualFans : MonoBehaviour {

    public GameObject FanMaster;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("On", FanMaster.GetComponent<Fan>().On);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FanMaster.GetComponent<Fan>().playerNear++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FanMaster.GetComponent<Fan>().playerNear++;
        }
    }
}
