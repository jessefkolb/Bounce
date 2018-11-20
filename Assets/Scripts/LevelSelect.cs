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

    public GameObject level5;
    public GameObject level6;
    public GameObject level7;
    public GameObject level8;

    public GameObject level9;
    public GameObject level10;
    public GameObject level11;
    public GameObject level12;

    public GameObject mainCanvas;
    public GameObject levelCanvas;

    private static string room = "ROOM";
    string ROOMinstant;
    string filename;

    Vector3 startingLocation;
    string level;

    // Use this for initialization
    void Start ()
    {

        if (!ES3.FileExists("LocationData_ROOM1.es3")) level1.GetComponent<Button>().interactable = false;
        if (!ES3.FileExists("LocationData_ROOM2.es3")) level2.GetComponent<Button>().interactable = false;
        if (!ES3.FileExists("LocationData_ROOM3.es3")) level3.GetComponent<Button>().interactable = false;
        if (!ES3.FileExists("LocationData_ROOM4.es3")) level4.GetComponent<Button>().interactable = false;
        if (!ES3.FileExists("LocationData_ROOM5.es3")) level5.GetComponent<Button>().interactable = false;
        if (!ES3.FileExists("LocationData_ROOM6.es3")) level6.GetComponent<Button>().interactable = false;

        if (!ES3.FileExists("LocationData_ROOM7.es3")) level7.GetComponent<Button>().interactable = false;
        if (!ES3.FileExists("LocationData_ROOM8.es3")) level8.GetComponent<Button>().interactable = false;
        if (!ES3.FileExists("LocationData_ROOM9.es3")) level9.GetComponent<Button>().interactable = false;
        if (!ES3.FileExists("LocationData_ROOM10.es3")) level10.GetComponent<Button>().interactable = false;
        if (!ES3.FileExists("LocationData_ROOM11.es3")) level11.GetComponent<Button>().interactable = false;
        if (!ES3.FileExists("LocationData_ROOM12.es3")) level12.GetComponent<Button>().interactable = false;


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
                /*
                if (i == 1) level1.GetComponent<Button>().interactable = false;
                if(i == 2) level2.GetComponent<Button>().interactable = false;
                if(i == 3) level3.GetComponent<Button>().interactable = false;
                if(i == 4) level4.GetComponent<Button>().interactable = false;
                if (i == 5) level5.GetComponent<Button>().interactable = false;
                if (i == 6) level6.GetComponent<Button>().interactable = false;
                if (i == 7) level7.GetComponent<Button>().interactable = false;
                if (i == 8) level8.GetComponent<Button>().interactable = false;
                if (i == 9) level9.GetComponent<Button>().interactable = false;
                if (i == 10) level10.GetComponent<Button>().interactable = false;
                if (i == 11) level11.GetComponent<Button>().interactable = false;
                if (i == 12) level12.GetComponent<Button>().interactable = false;
                */
            }
        }
	}
	
    public void Level1()
    {
        if(ES3.FileExists("LocationData_ROOM1.es3"))
        {
            if(ES3.FileExists("StartingLocation_ROOM1.es3"))
            {
                startingLocation = ES3.Load<Vector3>("startingLocation", "StartingLocation_ROOM1.es3");
                ES3.Save<Vector3>("Location", startingLocation, "LocationData_ROOM1.es3");
            }
        }

        SceneManager.LoadScene("ROOM1");
    }
    public void Level2()
    {
        if (ES3.FileExists("LocationData_ROOM2.es3"))
        {
            if (ES3.FileExists("StartingLocation_ROOM2.es3"))
            {
                startingLocation = ES3.Load<Vector3>("startingLocation", "StartingLocation_ROOM2.es3");
                ES3.Save<Vector3>("Location", startingLocation, "LocationData_ROOM2.es3");
            }
        }

        SceneManager.LoadScene("ROOM2");
    }
    public void Level3()
    {
        if (ES3.FileExists("LocationData_ROOM3.es3"))
        {
            if (ES3.FileExists("StartingLocation_ROOM3.es3"))
            {
                startingLocation = ES3.Load<Vector3>("startingLocation", "StartingLocation_ROOM3.es3");
                ES3.Save<Vector3>("Location", startingLocation, "LocationData_ROOM3.es3");
            }
        }

        SceneManager.LoadScene("ROOM3");
    }
    public void Level4()
    {
        if (ES3.FileExists("LocationData_ROOM4.es3"))
        {
            if (ES3.FileExists("StartingLocation_ROOM4.es3"))
            {
                startingLocation = ES3.Load<Vector3>("startingLocation", "StartingLocation_ROOM4.es3");
                ES3.Save<Vector3>("Location", startingLocation, "LocationData_ROOM4.es3");
            }
        }

        SceneManager.LoadScene("ROOM4");
    }
    public void Level5()
    {
        if (ES3.FileExists("LocationData_ROOM5.es3"))
        {
            if (ES3.FileExists("StartingLocation_ROOM5.es3"))
            {
                startingLocation = ES3.Load<Vector3>("startingLocation", "StartingLocation_ROOM5.es3");
                ES3.Save<Vector3>("Location", startingLocation, "LocationData_ROOM5.es3");
            }
        }

        SceneManager.LoadScene("ROOM5");

    }
    public void Level6()
    {

        if (ES3.FileExists("LocationData_ROOM6.es3"))
        {
            if (ES3.FileExists("StartingLocation_ROOM6.es3"))
            {
                startingLocation = ES3.Load<Vector3>("startingLocation", "StartingLocation_ROOM6.es3");
                ES3.Save<Vector3>("Location", startingLocation, "LocationData_ROOM6.es3");
            }
        }

        SceneManager.LoadScene("ROOM6");

    }
    public void Level7()
    {
        if (ES3.FileExists("LocationData_ROOM7.es3"))
        {
            if (ES3.FileExists("StartingLocation_ROOM7.es3"))
            {
                startingLocation = ES3.Load<Vector3>("startingLocation", "StartingLocation_ROOM7.es3");
                ES3.Save<Vector3>("Location", startingLocation, "LocationData_ROOM7.es3");
            }
        }

        SceneManager.LoadScene("ROOM7");

    }

    public void Level8()
    {
        if (ES3.FileExists("LocationData_ROOM8.es3"))
        {
            if (ES3.FileExists("StartingLocation_ROOM8.es3"))
            {
                startingLocation = ES3.Load<Vector3>("startingLocation", "StartingLocation_ROOM8.es3");
                ES3.Save<Vector3>("Location", startingLocation, "LocationData_ROOM8.es3");
            }
        }

        SceneManager.LoadScene("ROOM8");

    }

    public void Level9()
    {
        if (ES3.FileExists("LocationData_ROOM9.es3"))
        {
            if (ES3.FileExists("StartingLocation_ROOM9.es3"))
            {
                startingLocation = ES3.Load<Vector3>("startingLocation", "StartingLocation_ROOM9.es3");
                ES3.Save<Vector3>("Location", startingLocation, "LocationData_ROOM9.es3");
            }
        }

        SceneManager.LoadScene("ROOM9");

    }

    public void Level10()
    {
        if (ES3.FileExists("LocationData_ROOM10.es3"))
        {
            if (ES3.FileExists("StartingLocation_ROOM10.es3"))
            {
                startingLocation = ES3.Load<Vector3>("startingLocation", "StartingLocation_ROOM10.es3");
                ES3.Save<Vector3>("Location", startingLocation, "LocationData_ROOM10.es3");
            }
        }

        SceneManager.LoadScene("ROOM10");

    }

    public void Level11()
    {
        if (ES3.FileExists("LocationData_ROOM11.es3"))
        {
            if (ES3.FileExists("StartingLocation_ROOM11.es3"))
            {
                startingLocation = ES3.Load<Vector3>("startingLocation", "StartingLocation_ROOM11.es3");
                ES3.Save<Vector3>("Location", startingLocation, "LocationData_ROOM11.es3");
            }
        }

        SceneManager.LoadScene("ROOM11");

    }

    public void Level12()
    {
        if (ES3.FileExists("LocationData_ROOM12.es3"))
        {
            if (ES3.FileExists("StartingLocation_ROOM12.es3"))
            {
                startingLocation = ES3.Load<Vector3>("startingLocation", "StartingLocation_ROOM12.es3");
                ES3.Save<Vector3>("Location", startingLocation, "LocationData_ROOM12.es3");
            }
        }

        SceneManager.LoadScene("ROOM12");

    }

    public void Back()
    {
        mainCanvas.SetActive(true);
        levelCanvas.SetActive(false);
    }
}
