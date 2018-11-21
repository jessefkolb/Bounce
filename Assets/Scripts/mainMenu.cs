using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    public string startLevel;
    Scene scene;
    string sceneName;
    string key = "key";

    //figured we might use select level but we can take it out later if not
    public string selectLevel;

    public GameObject mainCanvas;
    public GameObject levelCanvas;
    public GameObject AreYouSure;
    bool newgame;

    bool yes;
    bool no;

    public void Start()
    {
        mainCanvas.SetActive(true);
        levelCanvas.SetActive(false);
        AreYouSure.SetActive(false);
    }

    public void newGame()
    {
        mainCanvas.SetActive(false);
        AreYouSure.SetActive(true);
    }

    public void loadGame()
    {
        if (ES3.FileExists("LocationData.es3"))
        {
            sceneName = ES3.Load<string>("Scene", "LocationData.es3");
            Debug.Log(sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else SceneManager.LoadScene("ROOM1");
    }

    public void battleMode()
    {
        SceneManager.LoadScene("BattleMode");
    }

    public void levelSelect()
    {
        levelCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }


    public void quitGame()
    {
        Application.Quit();
    }
}
