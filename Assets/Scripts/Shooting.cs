using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public static float AttackSpeed = 0.8f;
    public float bulletForce;
    public float AttackCooldown;
    public static int AttackMode = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (AttackCooldown < 0)
            {
                Shoot();
                AttackCooldown = AttackSpeed;
            }
        }
        AttackCooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        if (AttackMode == 1)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        if(AttackMode == 2)
        {
            GameObject bullet = Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce * 2, ForceMode2D.Impulse);
        }
        if (AttackMode == 3)
        {
            GameObject bullet = Instantiate(bulletPrefab3, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce((firePoint.up * bulletForce)/2, ForceMode2D.Impulse);
        }
    }
}
