using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {

    private static string key = "key";
    string keyInstant;
    string filename;
    private float xpos;
    private float ypos;
    private float zpos;

    private void Start()
    {
        xpos = GetComponent<Transform>().position.x;
        ypos = GetComponent<Transform>().position.y;
        zpos = GetComponent<Transform>().position.z;


        Vector3 v = new Vector3(xpos, ypos, zpos);

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
        Debug.Log(xpos);
        Vector3 v = new Vector3(xpos, ypos, zpos);
        ES3.Save<Vector3>(keyInstant, v, filename);

        Debug.Log(keyInstant);

        transform.localScale = new Vector3(0, 0, 0);
    }
}
