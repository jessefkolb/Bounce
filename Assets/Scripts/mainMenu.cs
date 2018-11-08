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
        if(ES3.FileExists("KeyNumber.es3"))
        {
            ES3.DeleteFile("KeyNumber.es3");
        }

        for(int i=0; i<60; i++)
        {
            key = "key" + i + ".es3";
            if (ES3.FileExists(key))
            {
                ES3.DeleteFile(key);
            }
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
