using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            Shooting.AttackSpeed -= 0.1f;
            Destroy(gameObject);
        }
    }

}
