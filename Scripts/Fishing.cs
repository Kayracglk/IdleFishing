using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public int currentFishStorage = 0;
    public int maxFishStorage = 5;
    public static Fishing instance;

    private void Awake()
    {
        instance = this;
    }

}
