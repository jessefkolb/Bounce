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
                else if (SceneManager.GetActiveScene().name == "ROOM4")
                {
                    if (Player.GetComponent<PlayerKeys>().numOfKeys >= 13) SceneManager.LoadScene("ROOM5");
                }
                else if (SceneManager.GetActiveScene().name == "ROOM5")
                {
                    if (Player.GetComponent<PlayerKeys>().numOfKeys >= 17) SceneManager.LoadScene("ROOM6");
                }
                else if (SceneManager.GetActiveScene().name == "ROOM6")
                {
                    if (Player.GetComponent<PlayerKeys>().numOfKeys >= 21) SceneManager.LoadScene("ROOM7");
                }
                else if (SceneManager.GetActiveScene().name == "ROOM7")
                {
                    if (Player.GetComponent<PlayerKeys>().numOfKeys >= 24) SceneManager.LoadScene("ROOM8");
                }
                else if (SceneManager.GetActiveScene().name == "ROOM8")
                {
                    if (Player.GetComponent<PlayerKeys>().numOfKeys >= 28) SceneManager.LoadScene("ROOM9");
                }
                else if (SceneManager.GetActiveScene().name == "ROOM9")
                {
                    if (Player.GetComponent<PlayerKeys>().numOfKeys >= 32) SceneManager.LoadScene("ROOM10");
                }
                else if (SceneManager.GetActiveScene().name == "ROOM10")
                {
                    if (Player.GetComponent<PlayerKeys>().numOfKeys >= 37) SceneManager.LoadScene("ROOM11");
                }
                else if (SceneManager.GetActiveScene().name == "ROOM11")
                {
                    if (Player.GetComponent<PlayerKeys>().numOfKeys >= 41) SceneManager.LoadScene("ROOM12");
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
