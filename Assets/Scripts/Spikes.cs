using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    bool s;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if(this.gameObject.CompareTag("Enemy") && collision.gameObject.GetComponent<playerControl>().sPress)
        {
            s = true;
        }

        if (collision.CompareTag("Player"))
        {
            if(!s) collision.SendMessage("TakeDamage", 1);
        }
    }
}

