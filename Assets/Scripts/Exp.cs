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
    public Vector2 playerPosition;
    public Vector2 expPosition;
    public Vector2 expMovement;
    public float expMovementLength;
    public float expSpeed;
    public float squareExpRange;
    public int RandomValue;

    // Start is called before the first frame update
    void Start()
    {
        expbody = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        expPosition = this.gameObject.transform.position;

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;


        expMovement = new Vector2((playerPosition.x - expPosition.x), (playerPosition.y - expPosition.y));


        expMovementLength = (float)Math.Sqrt((expMovement.x * expMovement.x) + (expMovement.y * expMovement.y));

        expMovement = new Vector2(expMovement.x / expMovementLength, expMovement.y / expMovementLength);

        if (expMovementLength < squareExpRange)
        {
            expbody.AddForce(expMovement * expSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D ExpCollider)
    {
        if (ExpCollider.transform.tag == "Player")
        {
            RandomValue = Random.Range(1, 14);
            FindObjectOfType<AudioManager>().Play("xp" + RandomValue);
            Consumables.ExpAmmount++;
            Destroy(gameObject);
        }
    }
}
