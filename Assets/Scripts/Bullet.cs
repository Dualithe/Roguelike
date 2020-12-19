using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int initialBulletDamage = 35;
    public static int bulletDamage = 35;
    public GameObject hitEffect;
    public GameObject bulletPrefab;
    public static float bulletLife = 0.6f;
    public Rigidbody2D rb;

    void Start()
    {

            Destroy(gameObject, bulletLife);

    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Wall")
        {
            StartCoroutine(hitWall());
        }
        else if (collision.transform.tag != "Pad" && collision.transform.tag != "Bullet" && collision.transform.tag != "Player" && collision.transform.tag != "Exp")
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
        } else if(collision.transform.tag != "Pad" && collision.transform.tag != "Bullet" && collision.transform.tag != "Player" && collision.transform.tag != "Exp")
        {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1f);
                Destroy(gameObject);
        }
 }
    IEnumerator hitWall()
    {
       yield return new WaitForSeconds(0.05f);
        rb.velocity = new Vector3(0, 0, 0);

    }

}
