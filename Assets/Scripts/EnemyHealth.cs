using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxBatHealth = 100;            
    public int BatHealth;
    private static int bDamage;
    public GameObject damageEffect;
    public float InvFrames = 0;

    void Start()
    {
        BatHealth = maxBatHealth;
    }

    void Update()
    {
        if(BatHealth <= 0)
        {
            Destroy(gameObject);
        }
        InvFrames -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            bDamage = Bullet.bulletDamage;
            if (InvFrames < 0)
            {
                DamageEnemy();
                InvFrames = 0.0001f;
            }
        }
    }

    public void DamageEnemy()
    {
            BatHealth -= bDamage;
            GameObject effect = Instantiate(damageEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
    }

}
