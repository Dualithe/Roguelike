using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using System;

public class MovementControlls : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float playerSpeed;
    private float dashingVectorLength;
    private Vector3 dashing;
    private GameObject playerObject = null;
    [SerializeField] private float dashPlayerSpeed = 800;
    private float dashCooldown = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (playerObject == null)
            playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;                                                                                 //save mouse position
        mousePos.z = 10;                                                                                                        //this line is there just so my cam can be at -10
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);                                                                    //conversion of the position

        dashing = new Vector3((mousePos.x - playerObject.transform.position.x), (mousePos.y - playerObject.transform.position.y), 0); //getting a directional vector

        dashingVectorLength = (float)Math.Sqrt((dashing.x * dashing.x) + (dashing.y * dashing.y) + (dashing.z * dashing.z));    //vector => versor

        dashing = new Vector3(dashing.x / dashingVectorLength, dashing.y / dashingVectorLength, 0);                              //saving versor into dashing

        if (Input.GetButtonUp("Jump"))
        {
            if (dashCooldown <= 0)
            {
                FindObjectOfType<AudioManager>().Play("Dash");
                StartCoroutine(dash());
            }
        }
        dashCooldown = dashCooldown - Time.deltaTime;                       //dash cooldown
    }

    void FixedUpdate()
    { 

        if (Input.GetButtonUp("Jump") == false)  //an addon for dash part of the script to get rid of artifacts
        {
            float x = Input.GetAxisRaw("Horizontal");    //simple 2d movement code
            float y = Input.GetAxisRaw("Vertical");
            Vector2 movement = new Vector2(x, y);        //Create a Vector2 called "movement" from the Horizonal and Vertical axis

            rb.velocity = (movement * playerSpeed);    //Use the Ridgidbody2d component to move the player in the direction of "movement" multiplied by "playerSpeed". Remember to set playerSpeed in the inspector.
        }

        //Set the player's rotation to face the mouse cursor. (probably gonna change it up if I want to angle my camera differently)
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);

    }
    
    IEnumerator dash()  //a dash coroutine, only a coroutine to access WaitForSeconds for the dash to be physically visible instead of an instant teleport that also launches enemies god knows where
    {
        Vector3 j = dashing;

        for (int i = 10; i != 0; i--) 
        {
            rb.AddForce(j * dashPlayerSpeed);
            yield return new WaitForSeconds(.01f);

        }

        dashCooldown = 1f;
    }
}
