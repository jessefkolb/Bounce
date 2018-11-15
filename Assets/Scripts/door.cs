using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    string scSave;
    string next;

    private void OnTriggerStay2D(Collider2D collision)
    {
       // Debug.Log("Entered");
        if(collision.CompareTag("Player") && Input.GetButtonDown("Interact"))
        {

           scSave = SceneManager.GetActiveScene().name + ".es3";
           ES3.Save<Scene>(SceneManager.GetActiveScene().name, SceneManager.GetActiveScene(), scSave);

           // if (SceneManager.GetActiveScene().name == "ROOM1") SceneManager.LoadScene("ROOM2");
           


            if (this.gameObject.CompareTag("door1")) SceneManager.LoadScene("Scene2");
            if (this.gameObject.CompareTag("door2"))
             {
                 SceneManager.LoadScene("Menu");
             }

        }

    }

}
