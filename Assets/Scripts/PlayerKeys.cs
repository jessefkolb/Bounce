using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour {

    int numOfKeys;

    void Start()
    {
        if(ES3.FileExists("KeyNumber.es3"))
        {
            numOfKeys = ES3.Load<int>("numOfKeys", "KeyNumber.es3");
        }
        else
        {
            numOfKeys = 0;
        }

        MenuDisplay.AddKeys(numOfKeys);
        Debug.Log("Number of keys: " + numOfKeys);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("key"))
        {
            collision.SendMessage("PickUp", numOfKeys);
            numOfKeys++;
            ES3.Save<int>("numOfKeys", numOfKeys, "KeyNumber.es3");
            MenuDisplay.AddKeys(numOfKeys);
            HUD.AddKeys(numOfKeys);
        }
    }
}
