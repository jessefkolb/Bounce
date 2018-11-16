using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuDisplay : MonoBehaviour {

    public static int keys;
    public static int health;
    public static int totalHealth;

	
	// Update is called once per frame
	void Update () {

        if(this.gameObject.CompareTag("keyMenu")) GetComponent<Text>().text = keys.ToString();
        if (this.gameObject.CompareTag("healthMenu1")) GetComponent<Text>().text = health.ToString();
        if (this.gameObject.CompareTag("healthMenu2")) GetComponent<Text>().text = totalHealth.ToString();

    }

    public static void AddKeys(int num)
    {
        keys = num;
    }

    public static void UpdateHealth(int currentHP, int totalHP)
    {
        health = currentHP;
        totalHealth = totalHP;
    }
}
