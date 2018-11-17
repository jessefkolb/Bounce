using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entered");
        if(collision.CompareTag("Player") && collision.gameObject.GetComponent<playerControl>().sPress)
        {
            Debug.Log("destroyed");
            this.gameObject.SetActive(false);
            //collision.gameObject.GetComponent<playerControl>().sPress = false;
        }
    }
}
