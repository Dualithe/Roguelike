using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : MonoBehaviour
{
    public static int ExpAmmount;
    // Start is called before the first frame update
    void Start()
    {
        ExpAmmount = 0;
    }

    void Update()
    {
        Debug.Log("" + ExpAmmount);
    }
}
