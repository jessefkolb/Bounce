using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    int totalHP;
    int currentHP;

    float immunityTimer;
    bool justHit;

    public GameObject HUD;

    public GameObject Damage;

	// Use this for initialization
	void Start ()
    {
        Damage.SetActive(false);

        if(ES3.FileExists("Health.es3"))
        {
            totalHP = ES3.Load<int>("totalHP");
        }
        else
        {
            totalHP = 5;
        }

        immunityTimer = 2;
        currentHP = totalHP;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(justHit)
        {
            Damage.SetActive(true);
            Damage.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (float)(immunityTimer * 0.25));
            immunityTimer -= Time.deltaTime;
        }
        else
        {
            Damage.SetActive(false);
        }

        if(immunityTimer <= 0)
        {
            justHit = false;
            immunityTimer = 2;
        }

		if(currentHP <= 0)
        {
            //GameOver
            HUD.SendMessage("EndGame");
        }

        MenuDisplay.UpdateHealth(currentHP, totalHP);
    }

    void TakeDamage(int damage)
    {
        if(immunityTimer == 2)
        {
            if ((currentHP - damage) >= 0) currentHP -= damage;
            else currentHP = 0;
        }

        justHit = true;
    }

    void Recover()
    {
        if(currentHP < totalHP) currentHP++;
    }

    void AddHealth()
    {
        totalHP++;
        currentHP = totalHP;
    }

}
