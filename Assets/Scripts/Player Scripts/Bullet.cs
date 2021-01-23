using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject bulletPrefab;
    public static float bulletLife = 0.6f;
    public static int bulletDamage = 35;
    public Rigidbody2D rb;

    void Awake()
    {
            Destroy(gameObject, bulletLife);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Wall")
        {
            StartCoroutine(hitWall());
        }
        else if (collision.transform.tag != "Pad" && collision.transform.tag != "Bullet" && collision.transform.tag != "Player" && collision.transform.tag != "Exp" && collision.transform.tag != "Floor" && collision.transform.tag != "Pad1" && collision.transform.tag != "Pad2" && collision.transform.tag != "Pad3") //series of exceptions that the arrow has to ignore (if the game goes further I might shorten this line of code for conveniences' sake)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Wall")
        {
            StartCoroutine(hitWall());
        } else if(collision.transform.tag != "Pad" && collision.transform.tag != "Bullet" && collision.transform.tag != "Player" && collision.transform.tag != "Exp" && collision.transform.tag != "Floor" && collision.transform.tag != "Pad1" && collision.transform.tag != "Pad2" && collision.transform.tag != "Pad3")//exactly as said above ^^^
        {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1f);
                Destroy(gameObject);
        }
 }
    IEnumerator hitWall()
    {
       yield return new WaitForSeconds(0.02f);
        rb.velocity = new Vector3(0, 0, 0);

    }
}
