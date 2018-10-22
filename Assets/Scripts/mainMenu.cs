using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    public string startLevel;

    //figured we might use select level but we can take it out later if not
    public string selectLevel;

    public void newGame(){
        //not sure if this is the right way for our game
        //Application.LoadLevel(startLevel);

        SceneManager.LoadScene("Demo1");
    }

    public void levelSelect(){
        //Application.LoadLevel(selectLevel);
    }

    public void quitGame(){
        Application.Quit();
    }

    //need to figure out how to implement this.
    public void saveGame(){

    }
}
