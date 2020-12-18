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
    public float speed;
    private float dashingVectorLength;
    private Vector3 dashing;
    private GameObject playerObj = null;
    public float dashSpeed;
    public float dashCooldown = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        //*****************************************************************************************************************//
        /*                                     MECHANIKA DASHA NIE RUSZAĆ BO SIĘ SYPNIE                                   */
        //*****************************************************************************************************************//
        Vector3 mousePos = Input.mousePosition;                                                                                 //zapisujemy pozycję myszy w nowym wektorze
        mousePos.z = 10;                                                                                                        //ustawiamy z na 10 żeby móc oddalić kamerę o 10 jednostek
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);                                                                    //konwertujemy pozycję myszy na pozycję w świecie

        dashing = new Vector3((mousePos.x - playerObj.transform.position.x), (mousePos.y - playerObj.transform.position.y), 0); //odejmujemy odpowiednie wartości aby dostać kierunek

        dashingVectorLength = (float)Math.Sqrt((dashing.x * dashing.x) + (dashing.y * dashing.y) + (dashing.z * dashing.z));    //normalizujemy wektor 

        dashing = new Vector3(dashing.x / dashingVectorLength, dashing.y / dashingVectorLength, 0);                              //zapisujemy znormalizowany wektor w dashing                                                                             //sprawdzamy input

        //IsSpaceDown = Input.GetKeyDown("space");

        if (Input.GetButtonUp("Jump"))
        {
            if (dashCooldown <= 0)
            {
                FindObjectOfType<AudioManager>().Play("Dash");
                StartCoroutine(dash());
                // rb.AddForce(dashing * dashSpeed);
                // FindObjectOfType<AudioManager>().Play("Dash");
                // dashCooldown = 1.5f;
            }                                                                                 //jeśli wykryje input to wektor o długości jeden który pokazuje kierunek mnożymy razy dashSpeed ustawiony w Unity2D i siema
        }
        dashCooldown = dashCooldown - Time.deltaTime;

        //*****************************************************************************************************************//
        /*                                     MECHANIKA DASHA NIE RUSZAĆ BO SIĘ SYPNIE                                   */
        //*****************************************************************************************************************//
    }
        private void FixedUpdate()
        { 

        if (Input.GetButtonUp("Jump") == false)  //Dodatek do dasha, wyłącza movement podczas dasha aby nie było niepotrzebnych artefaktów
        {
            //               Player movement code              //

            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            Vector2 movement = new Vector2(x, y);        //Create a Vector2 called "movement" from the Horizonal and Vertical axis

            rb.velocity = (movement * speed);            //Use the Ridgidbody2d component to move the player in the direction of "movement" multiplied by "speed". Remember to set speed in the inspector.
        }

        //Set the player's rotation to face the mouse cursor.
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);

        }
    
    IEnumerator dash()
    {
        Vector3 j = dashing;

        for (int i = 10; i != 0; i--) 
        {
            rb.AddForce(j * dashSpeed);
            yield return new WaitForSeconds(.01f);

        }

        dashCooldown = 1f;
    }
}
