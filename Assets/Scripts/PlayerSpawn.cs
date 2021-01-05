using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    List<Collider> collidedObjects = new List<Collider>();
    public Vector3 startingPosition;

    void Start()
    {
        Scan();
        SpawnPlayer();

    }

    void FixedUpdate()
    {
       // if (collidedObjects.Count == 2)
      // {
         //   Debug.Log("" + collidedObjects.Count);
        //}
        //collidedObjects.Clear();     //clearing the list
    }




    void Scan()
    {

        //Starting coordinates are x: -75, y: 220
        //End coordinates are x: 220, y: -75 

        //startingPosition = transform.position;
        for (int i = 0; i < 60; i++)
        {
            for (int j = 0; j < 59; j++)
            {

                transform.position = transform.position + new Vector3(5, 0, 0);
                Debug.Log("" + collidedObjects.Count);
            }
            transform.position = transform.position - new Vector3(295, 0, 0);
            transform.position = transform.position + new Vector3(0, -5, 0);
        }
    }



    void SpawnPlayer()
    {

    }

    void OnTriggerEnter2D(Collider2D wallCol)
    {
        if (!collidedObjects.Contains(wallCol.GetComponent<Collider>()) && wallCol.GetComponent<Collider>().tag == "Wall")
        {
            collidedObjects.Add(wallCol.GetComponent<Collider>());
        }
    }

    void OnTriggerStay2D(Collider2D wallCol)
    {
        OnTriggerEnter2D(wallCol);
    }
}


