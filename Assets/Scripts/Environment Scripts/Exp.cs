using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class Exp : MonoBehaviour
{
    private Rigidbody2D expbody;
    private Vector2 playerPosition;
    private Vector2 expPosition;
    private Vector2 expMovement;
    private float expMovementAbsolute;
    [SerializeField] private float expSpeed;
    [SerializeField] private float squareExpRange;
    private int randomValue;

    void Start()
    {
        expbody = GetComponent<Rigidbody2D>();
       
    }

    void FixedUpdate()
    {
        expPosition = this.gameObject.transform.position;

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;


        expMovement = new Vector2((playerPosition.x - expPosition.x), (playerPosition.y - expPosition.y));

        expMovementAbsolute = (float)Math.Sqrt((expMovement.x * expMovement.x) + (expMovement.y * expMovement.y));

        expMovement = new Vector2(expMovement.x / expMovementAbsolute, expMovement.y / expMovementAbsolute);

        if (expMovementAbsolute < squareExpRange) 
        {
            expbody.AddForce(expMovement * expSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D ExpCollider)
    {
        if (ExpCollider.transform.tag == "Player")
        {
            randomValue = Random.Range(1, 14);
            FindObjectOfType<AudioManager>().Play("xp" + randomValue);
            Consumables.ExpAmmount++;
            Destroy(gameObject);
        }
    }
}
