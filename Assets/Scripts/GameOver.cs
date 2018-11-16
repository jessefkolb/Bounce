using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour {

    bool gameOver;
    public GameObject GOCanvas;

    // Use this for initialization
    void Update()
    {
        if(gameOver)
        {
            GOCanvas.SetActive(true);
        }
    }

    public void EndGame()
    {
        gameOver = true;
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
