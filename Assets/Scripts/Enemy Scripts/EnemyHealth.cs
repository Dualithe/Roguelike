using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int maxBatHealth = 100;            
    private int batHealth;
    private static int batDamage;
    [SerializeField] private GameObject damageEffect;  //particles needed to be assigned in the inspector
    private float InvFrames = 0;

    void Start()
    {
        batHealth = maxBatHealth;
    }

    void Update()
    {
        if(batHealth <= 0)
        {
            Destroy(gameObject);
        }
        InvFrames -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            batDamage = Bullet.bulletDamage;
            if (InvFrames < 0)
            {
                DamageEnemy();
                InvFrames = 0.0001f;
            }
        }
    }

     void DamageEnemy()
    {
            batHealth -= batDamage;
            GameObject effect = Instantiate(damageEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.5f);
    }

}
