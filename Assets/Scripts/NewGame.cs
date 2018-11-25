using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

    public GameObject mainCanvas;
    public GameObject AreYouSure;
    public GameObject Success;

    public void yes()
    {
        ES3.DeleteDirectory("");
        AreYouSure.SetActive(false);
        Success.SetActive(true);
    }

    public void no()
    {
        AreYouSure.SetActive(false);
        Success.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
