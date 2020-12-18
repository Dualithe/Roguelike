using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{

    public int batDamage;                        //public 4 balancing
    public int maxHealth = 100;                    //public 4 balancing
    public int currentHealth;                      //public 4 testing
    public float invincibilityFrames;             //public 4 balancing

    public HealthBarUI healthBar;                 //had to be implemented to work with ui health bar


    private void OnTriggerStay2D(Collider2D other) //collider 4 damage taking fuuuug
    {
        if(invincibilityFrames <= 0)
        {      
                TakeDamage(other);
        }
    }

    void Start()                 //hp
    {
        currentHealth = maxHealth;
    }

    void Update()                //invFrames updater
    {
        invincibilityFrames = invincibilityFrames - Time.deltaTime;
    }

    void TakeDamage(Collider2D collision)            //damage fuuuuuuuuuuug
    {
        if (collision.transform.tag == "Bat") 
        {
            currentHealth -= batDamage;

            healthBar.SetHealth(currentHealth);

            invincibilityFrames = .2f;        //1 seems to work fine but will be less if i decide to increase difficulty

            FindObjectOfType<AudioManager>().Play("Hit");
        }
    }
}
