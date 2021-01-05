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
    public Vector2 playerPosition;
    public Vector2 batPosition;
    public Vector2 batMovement;
    public float batMovementLength;
    public float batSpeed;


    void Start()
    {
        batbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        batPosition = this.gameObject.transform.position;

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;


        batMovement = new Vector2 ((playerPosition.x - batPosition.x), (playerPosition.y - batPosition.y));

        batMovementLength = (float)Math.Sqrt((batMovement.x * batMovement.x) + (batMovement.y * batMovement.y));   

        batMovement = new Vector2(batMovement.x / batMovementLength, batMovement.y / batMovementLength);

        batbody.AddForce(batMovement * batSpeed);
    }
    void OnTriggerEnter2D(Collider2D batCol)
    {
        if (batCol.transform.tag == "Bullet" || batCol.transform.tag == "Player" || batCol.transform.tag == "Bat" || batCol.transform.tag == "Wall")
        {

            batbody.AddForce((-batMovement * batSpeed) / 3, ForceMode2D.Impulse);
        }
    }

}
