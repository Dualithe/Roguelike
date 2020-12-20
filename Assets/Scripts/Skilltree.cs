using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Skilltree : MonoBehaviour
{
  private void Awake()
    {
        transform.Find("skillButton").GetComponent<Button_UI>().ClickFunc = () =>
        {
            Debug.Log("Click!");
        };
}
    
        
    


}
