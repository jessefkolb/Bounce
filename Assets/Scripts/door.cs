using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    string scSave;
    string next;
    public GameObject Player;
    public GameObject Canvas;

    private void OnTriggerStay2D(Collider2D collision)
    {

        Canvas.SetActive(true);

        // Debug.Log("Entered");
        if (collision.CompareTag("Player"))
        {
            if(Input.GetButtonDown("Interact"))
            {
                scSave = SceneManager.GetActiveScene().name + ".es3";
                ES3.Save<Scene>(SceneManager.GetActiveScene().name, SceneManager.GetActiveScene(), scSave);

                if (SceneManager.GetActiveScene().name == "ROOM1")
                {
                    if (Player.GetComponent<PlayerKeys>().numOfKeys >= 3)
                    {
                        SceneManager.LoadScene("ROOM2");
                    }
                }
                else if (SceneManager.GetActiveScene().name == "ROOM2")
                {
                    if (Player.GetComponent<PlayerKeys>().numOfKeys >= 6) SceneManager.LoadScene("ROOM3");
                }
                else if (SceneManager.GetActiveScene().name == "ROOM3")
                {
                    if (Player.GetComponent<PlayerKeys>().numOfKeys >= 9) SceneManager.LoadScene("ROOM4");
                }
                else if (SceneManager.GetActiveScene().name == "ROOM12")
                {
                    SceneManager.LoadScene("THEEND");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) Canvas.SetActive(false);
    }

}
