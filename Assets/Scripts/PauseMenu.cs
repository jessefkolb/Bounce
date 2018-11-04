using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public bool isPaused;
    public GameObject pauseMenuCanvas;
    //public GameObject managerScript;

    private bool hasDoubleJump;
    private bool hasAirDash;
    private bool hasDashBomb;

	// Update is called once per frame
	void Update () {

        if(isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
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

    public void Save()
    {
        /*
        ManagerScript script = managerScript.GetComponent<ManagerScript>();
        ES3.Save<bool>("hasDoubleJump", script.hasDoubleJump);
        ES3.Save<bool>("hasAirDash", script.hasAirDash);
        ES3.Save<bool>("hasDashBomb", script.hasDashBomb);
        */
        Debug.Log("Saved");
    }

    public void Load()
    {
        /*
        hasDoubleJump = ES3.Load<bool>("hasDoubleJump");
        hasAirDash = ES3.Load<bool>("hasAirDash");
        hasDashBomb = ES3.Load<bool>("hasDashBomb");
        */
        Debug.Log("Loaded");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
