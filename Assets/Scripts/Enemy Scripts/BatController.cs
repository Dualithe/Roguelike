using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using System;

public class BatController : MonoBehaviour
{

    //                                           Control the bat
    private Rigidbody2D batbody;
    private Vector2 playerPosition;
    private Vector2 batPosition;
    private Vector2 batMovementVector;
    private float batMovementLength;
    private bool batAggro = false;
    private float dashAbilityCooldownOperational;
    [SerializeField] private float dashAbilityCooldown;
    [SerializeField] private float dashAbilityForce;
    [SerializeField] private float dashAbilityRange;
    [SerializeField] private float batAggroRange;
    [SerializeField] private float batSpeed = 40;
    [SerializeField] public static int batDamage = 25;



    void Start()
    {
        dashAbilityCooldownOperational = 0;
        batbody = GetComponent<Rigidbody2D>();
        batAggro = false;
    }

    void FixedUpdate()
    {
        batPosition = this.gameObject.transform.position;

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;


        batMovementVector = new Vector2((playerPosition.x - batPosition.x), (playerPosition.y - batPosition.y));

        batMovementLength = (float)Math.Sqrt((batMovementVector.x * batMovementVector.x) + (batMovementVector.y * batMovementVector.y));

        batMovementVector = new Vector2(batMovementVector.x / batMovementLength, batMovementVector.y / batMovementLength);

        if (batMovementLength < batAggroRange)
        {
            batAggro = true;
        }
        if (batAggro == true && batMovementLength > dashAbilityRange - 2f)
        {
            batbody.AddForce(batMovementVector * batSpeed);
        }
        if (dashAbilityCooldownOperational <= 0) {
            if (batMovementLength < dashAbilityRange)
            {
                batbody.AddForce(batMovementVector * batSpeed * dashAbilityForce);
            }
            dashAbilityCooldownOperational = dashAbilityCooldown;
        }

        dashAbilityCooldownOperational -= Time.deltaTime;
    }




    void OnTriggerEnter2D(Collider2D batCol)
    {
        if (batCol.transform.tag == "Bullet" || batCol.transform.tag == "Player" || batCol.transform.tag == "Bat" || batCol.transform.tag == "Wall")
        {
            if (batCol.transform.tag == "Player")
            {
                if (PlayerHealth.currentInvincibilityFrames <= 0)
                {
                    PlayerHealth.currentHealth -= batDamage;
                    PlayerHealth.currentInvincibilityFrames = PlayerHealth.invincibilityFrames;        //.2 seems to work fine but will be less if i decide to increase difficulty
                    FindObjectOfType<AudioManager>().Play("Hit");
                }
                if (dashAbilityCooldownOperational > 0)
                {
                    batbody.AddForce(-batMovementVector * batSpeed * dashAbilityForce * 1.35f);
                }


            }  

            batbody.AddForce((-batMovementVector * batSpeed) / 3, ForceMode2D.Impulse);
        }
    }

    void OnTriggerStay2D(Collider2D batCol)
    {
        if (batCol.transform.tag == "Bullet" || batCol.transform.tag == "Player" || batCol.transform.tag == "Bat" || batCol.transform.tag == "Wall")
        {
            if (batCol.transform.tag == "Player")
            {
                if (PlayerHealth.currentInvincibilityFrames <= 0)
                {
                    PlayerHealth.currentHealth -= batDamage;
                    PlayerHealth.currentInvincibilityFrames = PlayerHealth.invincibilityFrames;        //.2 seems to work fine but will be less if i decide to increase difficulty
                    FindObjectOfType<AudioManager>().Play("Hit");
                }
            }

            batbody.AddForce((-batMovementVector * batSpeed) / 3, ForceMode2D.Impulse);
        }
    }

}
