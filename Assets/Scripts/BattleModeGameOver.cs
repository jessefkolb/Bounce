using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleModeGameOver : MonoBehaviour {

    bool gameOver;
    public GameObject GOCanvas;
    public GameObject fadeCanvas;
    float timer;

    // Use this for initialization
    private void Start()
    {
        timer = 2;
    }

    void Update()
    {
        if (gameOver)
        {
            timer -= (float)0.01;
            GOCanvas.SetActive(true);

            if (timer <= 0)
            {
                SceneManager.LoadScene("Menu");
            }

            if (timer < 1)
            {
                if (timer > 0) fadeCanvas.GetComponent<Image>().color = new Color(1, 1, 1, timer);
            }
        }
    }

    public void EndGame()
    {
        gameOver = true;
        Time.timeScale = 0f;
    }
}
