using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    public string startLevel;
    Scene scene;
    string sceneName;

    //figured we might use select level but we can take it out later if not
    public string selectLevel;

    public void newGame()
    {
        if(ES3.FileExists("SaveData.es3"))
        {
            ES3.DeleteFile("SaveData.es3");
        }
        if(ES3.FileExists("LocationData.es3"))
        {
            ES3.DeleteFile("LocationData.es3");
        }

        SceneManager.LoadScene("Scene1");

    }

    public void levelSelect()
    {
        if (ES3.FileExists("LocationData.es3"))
        {
            sceneName = ES3.Load<string>("Scene", "LocationData.es3");
            Debug.Log(sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else SceneManager.LoadScene("Scene1");
    }

    public void quitGame(){
        Application.Quit();
    }
}
