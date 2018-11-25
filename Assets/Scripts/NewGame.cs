using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class NewGame : MonoBehaviour {

    public GameObject mainCanvas;
    public GameObject AreYouSure;
    public GameObject Success;

    public void yes()
    {
        AreYouSure.SetActive(false);
        Success.SetActive(true);
        ES3.DeleteDirectory("");
    }

    public void no()
    {
        AreYouSure.SetActive(false);
        Success.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
