using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] public static int currentHealth; 
    [SerializeField] public static float invincibilityFrames = 0.5f;
    public static float currentInvincibilityFrames;
    public HealthBarUI healthBar;                 //had to be implemented to work with ui health bar

    void Start() 
    {
        currentInvincibilityFrames = 0;  //just so it has a value 
        currentHealth = maxHealth;                //set the hp to 100%

    }

    void Update()
    {
        healthBar.SetHealth(currentHealth);
        currentInvincibilityFrames -= Time.deltaTime;                //invFrames updater
    }

}
