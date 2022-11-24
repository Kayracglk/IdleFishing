using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchButton : MonoBehaviour
{
    [SerializeField] private GameObject[] oltalar;
    private CatchFish catchFish;

    public void catchButton()
    {
        oltalar = GameObject.FindGameObjectsWithTag("Olta");

        foreach (GameObject olta in oltalar)
        {
            catchFish = olta.GetComponent<CatchFish>();
            if(!catchFish.isCatching)
            {
                StartCoroutine(catchFish.CatchingFish());
                catchFish.isCatching = true;
            }
            
        }
    }

}
