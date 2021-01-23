using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMode : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col1)
    {
        if (col1.transform.tag == "Player")
        {
            if (this.transform.tag == "Pad1")
            {
                Shooting.AttackSpeed -= 0.2f;
                Bullet.bulletLife = 0.3f;
                if (Bullet.bulletDamage - 15 > 0)
                {
                    Bullet.bulletDamage -= 15;
                }
                Shooting.AttackMode = 2;
            }else if(this.transform.tag == "Pad2")
            {
                Shooting.AttackSpeed -= 0.1f;
            }else if(this.transform.tag == "Pad3")
            {
                Bullet.bulletLife = 1f;
                Bullet.bulletDamage += 15;
                Shooting.AttackMode = 3;
            }
            Destroy(gameObject);
        }
    }
}
