using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuDisplay : MonoBehaviour {

    public static int keys;

	
	// Update is called once per frame
	void Update () {

        GetComponent<Text>().text = keys.ToString();
	}

    public static void AddKeys(int num)
    {
        keys = num;
    }
}
