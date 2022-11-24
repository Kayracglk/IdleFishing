using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellFish : MonoBehaviour
{
    [SerializeField] private GameObject catchButton;
    public int fishPayment = 1;
    [SerializeField] private GameObject[] oltalar;
    private CatchFish catchFish;
    private int count = 0;
    private void OnTriggerExit(Collider other)
    {
        catchButton.SetActive(true);

    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            
            catchButton.SetActive(false);
            oltalar = GameObject.FindGameObjectsWithTag("Olta");
            foreach (GameObject olta in oltalar)
            {
                catchFish = olta.GetComponent<CatchFish>();
                fishPayment = catchFish.fishPayments[count];
                if (catchFish.isCatching)
                {
                    catchFish.isCatching = false;
                    CashManager.instance.totalCash += fishPayment;
                    count++;
                }

            }
            while (Fishing.instance.currentFishStorage > 0)
            {
                Fishing.instance.currentFishStorage --;
                CashManager.instance.totalCash += fishPayment;
            }

        }
    }
}

