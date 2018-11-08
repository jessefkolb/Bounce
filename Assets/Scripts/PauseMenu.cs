using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public bool isPaused;
    bool timeIsOne;
    public GameObject pauseMenuCanvas;
    //public GameObject managerScript;


    private bool hasDoubleJump;
    private bool hasAirDash;
    private bool hasDashBomb;

    private void Start()
    {
        isPaused = false;
        timeIsOne = true;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update () {

        if(isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            timeIsOne = false;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            while(!timeIsOne)
            {
                Time.timeScale = 1f;
                timeIsOne = true;
            }
        }
        if(Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
        }
		
	}

    public void Resume()
    {
        isPaused = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
