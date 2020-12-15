using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public int batsFirstWave;
    public int batsPerWave;
    public int timeToNextWave;

    void FixedUpdate()
    {
        if(GameObject.FindWithTag("Bat") == null)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        Debug.Log("Next wave is starting!");
        //wait 10 seconds and spawn x bats over y time

    }

}
