using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
       // Debug.Log("Entered");
        if(collision.CompareTag("Player") && Input.GetButtonDown("Interact"))
        {
           if (this.gameObject.CompareTag("door1")) SceneManager.LoadScene("Scene2");
           if (this.gameObject.CompareTag("door2"))
            {
                SceneManager.LoadScene("Menu");
            }
                
        }

    }

}
