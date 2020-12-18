using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackModeChange2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col1)
    {
        if (col1.transform.tag == "Player")
        {
            Shooting.AttackSpeed -= 0.2f; 
            Bullet.bulletLife = 0.3f;
            if (Bullet.bulletDamage - 15 > 0)
            {
                Bullet.bulletDamage -= 15;
            }
            Shooting.AttackMode = 2;
            Destroy(gameObject);
        }
    }
}
