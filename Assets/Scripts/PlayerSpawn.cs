using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    List<Collider2D> collidedObjects = new List<Collider2D>();
   // public Vector3 startingPosition;
    public GameObject spawnpoint;
    public Rigidbody2D rb;
    public Collider2D colli;
    public int i = 0;

    void Start()
    {
        StartCoroutine("ScanMap");
        //ScanMap(colli);
    }

    void FixedUpdate()
    {
       // if (collidedObjects.Count == 2)
      // {
         //   Debug.Log("" + collidedObjects.Count);
        //}
        //collidedObjects.Clear();     //clearing the list
    }

    IEnumerator ScanMap()
    {
        yield return new WaitForSeconds(.1f);
        ScanMap(colli);
    }


    void ScanMap(Collider2D colli)
    {

        //Starting coordinates are x: -75, y: 220
        //End coordinates are x: 220, y: -75 

        //startingPosition = transform.position;

        for (int i = 0; i < 60; i++)
        {
            for (int j = 0; j < 59; j++)
            {

                transform.position = transform.position + new Vector3(5, 0, 0);
                /*                if (colli.transform.tag == "Wall")
                                {
                                    XSearch(colli);
                                }*/
                OnTriggerEnter2D(colli);

                OnTriggerStay2D(colli);
            }
            transform.position = transform.position - new Vector3(295, 0, 0);
            transform.position = transform.position + new Vector3(0, -5, 0);
        }
    }



    void OnTriggerEnter2D(Collider2D colli)
    {
         /*if (!collidedObjects.Contains(colli.GetComponent<Collider2D>()) && colli.GetComponent<Collider2D>().tag == "Wall")
         {
            Debug.Log("kutas" + i);
            i++;
            XSearch(colli);
            //collidedObjects.Add(colli.GetComponent<Collider>());
        }*/

        if (colli.gameObject.tag == "Wall")  //doesn't work yet
        {
            Debug.Log("kutas" + i);
            i++;
            XSearch(colli);
        }
    }



    void OnTriggerStay2D(Collider2D colli)
    {
        OnTriggerEnter2D(colli);
    }



    public void XSearch(Collider2D colli)
    {
        bool BottomRight = false;
        bool BottomLeft = false;
        bool TopRight = false;
        bool TopLeft = false;

        transform.position = transform.position + new Vector3(5, 5, 0);

        if (colli.gameObject.tag == "Wall")
        {
            TopRight = true;
        }
        transform.position = transform.position + new Vector3(0, -10, 0);

        if (colli.gameObject.tag == "Wall")
        {
            BottomRight = true;
        }

        transform.position = transform.position + new Vector3(-10, 0, 0);

        if (colli.gameObject.tag == "Wall")
        {
            BottomLeft = true;
        }

        transform.position = transform.position + new Vector3(10, 0, 0);

        if (colli.gameObject.tag == "Wall")
        {
            TopLeft = true;
        }

        transform.position = transform.position + new Vector3(5, -5, 0);

        //Spawnpoint recognition
        if (TopRight == true && TopLeft == true)
        {
            Instantiate(spawnpoint, new Vector3(colli.transform.position.x, colli.transform.position.y + 5, 0), Quaternion.identity);
        }
        if (BottomRight == true && BottomLeft == true)
        {
            Instantiate(spawnpoint, new Vector3(colli.transform.position.x, colli.transform.position.y - 5, 0), Quaternion.identity);
        }
        if (TopRight == true && BottomRight == true)
        {
            Instantiate(spawnpoint, new Vector3(colli.transform.position.x + 5, colli.transform.position.y, 0), Quaternion.identity);
        }
        if (TopLeft == true && BottomLeft == true)
        {
            Instantiate(spawnpoint, new Vector3(colli.transform.position.x - 5, colli.transform.position.y, 0), Quaternion.identity);
        }



    }
}



