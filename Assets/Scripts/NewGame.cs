using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

    public GameObject mainCanvas;
    public GameObject AreYouSure;

    public void yes()
    {
        ES3.DeleteDirectory("");
        SceneManager.LoadScene("ROOM1");
    }

    public void no()
    {
        AreYouSure.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
