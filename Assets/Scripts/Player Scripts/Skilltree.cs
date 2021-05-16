using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skilltree : MonoBehaviour
{
    private void Awake()
    {
        int firstRow = 2;

        if (Consumables.ExpAmmount > 0)
        {
            switch (firstRow)
            {
                case 1:
                    Debug.Log("You have upgraded the ability no." + firstRow);
                    Consumables.ExpAmmount--;
                    break;
                case 2:
                    Debug.Log("You have upgraded the ability no." + firstRow);
                    Consumables.ExpAmmount--;
                    break;
                case 3:
                    Debug.Log("You have upgraded the ability no." + firstRow);
                    Consumables.ExpAmmount--;
                    break;
                case 4:
                    Debug.Log("You have upgraded the ability no." + firstRow);
                    Consumables.ExpAmmount--;
                    break;
                case 5:
                    Debug.Log("You have upgraded the ability no." + firstRow);
                    Consumables.ExpAmmount--;
                    break;
                case 6:
                    Debug.Log("You have upgraded the ability no." + firstRow);
                    Consumables.ExpAmmount--;
                    break;
            }
        }
    }







}
