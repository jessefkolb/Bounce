﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{

    public int max_hp;          // set in unity, in the player asset itself
    public int current_hp;     // current health, used for calculations
    bool isDead = false;   // checks when player dies
    float Damage_timer;
    public bool Can_Take_Damage;
    public float Damage_Cooldown;

 

    public static Player_Health instance = null;

     void Awake()
     {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
     }

    void Start()
    {
        // Initialize our hp
        current_hp = max_hp;

        Can_Take_Damage = true;
        Damage_timer = .5f;

    }



    void Update()
    {
        if (!Can_Take_Damage)
        {
            Damage_timer -= Time.deltaTime;
            if(Damage_timer <= 0)
            {
                Can_Take_Damage = true;
                Damage_timer = .5f;
            }
           
        }
        
    }
    // Inflicts damage and check if the object should be destroyed
    public void Damage(int damageCount)
    {
        if (Can_Take_Damage)
        {
            

            if (current_hp <= 0 && !isDead)
            {
                // Dead!
                PlayerDies();
            }
            Can_Take_Damage = false;
        }
        else
        {
            //do nothing
        }
        
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
      
        // Is this a shot?
        Enemy_Projectile shot = otherCollider.gameObject.GetComponent<Enemy_Projectile>();
        if (shot != null)
        {
            Damage(shot.damage); //inflict damage

            // Destroy the shot
            Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
        }
    }

    // When the player dies, deletes player object, and calls Game Over scene
    void PlayerDies()
    {
        isDead = true; // set to true
        Destroy(gameObject); // destroy player
    }

    //when player clears a level, it regens 5 health points
    public void Health_Regen() 
    {
        if (max_hp >= (current_hp + 5)) //check the regen won't go over max_hp
        {
            current_hp += 5;
        }
        else //otherwise raise it back to max_hp
        {
            current_hp = max_hp;
        }
    }
}
