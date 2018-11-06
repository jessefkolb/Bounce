using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {

    private static string key = "key";
    string keyInstant;
    string filename;

    private void Start()
    {
        Vector3 v = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);

        for (int i=0; i<60; i++)
        {
            keyInstant = key + i.ToString();
            filename = keyInstant + ".es3";

            if (ES3.FileExists(filename))
            {
                Vector3 l = ES3.Load<Vector3>(keyInstant, filename);
                if (v == l)
                {
                    transform.localScale = new Vector3(0, 0, 0);
                }
            }
        }
    }

    void PickUp(int numOfKeys)
    {
        keyInstant = key + numOfKeys.ToString();
        filename = keyInstant + ".es3";
        Vector3 v = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
        ES3.Save<Vector3>(keyInstant, v, filename);

        Debug.Log(keyInstant);

        transform.localScale = new Vector3(0, 0, 0);
    }
}
