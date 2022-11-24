using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFish : MonoBehaviour
{
    public bool isCatching = false;
    public List<int> fishPayments = new List<int>();
    public IEnumerator CatchingFish()
    {
        yield return new WaitForSeconds(Random.Range(5.0f,10.0f));
        if(Fishing.instance.maxFishStorage > Fishing.instance.currentFishStorage)
        {
            fishPayments.Add(Random.Range(1, 3));
            Fishing.instance.currentFishStorage += 1;
            isCatching = false;
        }

    }
}
