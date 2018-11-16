using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;

    public GameObject mainCanvas;
    public GameObject levelCanvas;

    private static string room = "ROOM";
    string ROOMinstant;
    string filename;

    string level;

    // Use this for initialization
    void Start ()
    {
        for (int i = 1; i <= 12; i++)
        {
            ROOMinstant = room + i.ToString();
            filename = ROOMinstant + ".es3";

            if (ES3.FileExists(filename))
            {
                Scene scene = ES3.Load<Scene>(ROOMinstant, filename);
            }
            else
            {
                if(i == 1) level1.GetComponent<Button>().interactable = false;
                if(i == 2) level2.GetComponent<Button>().interactable = false;
                if(i == 3) level3.GetComponent<Button>().interactable = false;
                if(i == 4) level4.GetComponent<Button>().interactable = false;
            }
        }
	}
	
    public void Level1()
    {
        SceneManager.LoadScene("ROOM1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("ROOM2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("ROOM3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("ROOM4");
    }
    public void Level5()
    {

    }
    public void Level6()
    {

    }
    public void Level7()
    {

    }
    public void Back()
    {
        mainCanvas.SetActive(true);
        levelCanvas.SetActive(false);
    }
}
