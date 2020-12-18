using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackModeChange3 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.transform.tag == "Player")
        {
            Bullet.bulletLife = 1f;
            Bullet.bulletDamage += 15;
            Shooting.AttackMode = 3;
            Destroy(gameObject);
        }
    }
}
