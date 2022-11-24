using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BoatChance : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject[] boats;
    private int boatRodCount = 1;
    private int boatMaxRodCount = 1;
    private int count = 0;
    private int newBoatPrize = 600;
    private int newRodPrize = 300;

    [SerializeField] TextMeshProUGUI boatText;
    [SerializeField] TextMeshProUGUI rodText;

    private void Awake()
    {
        boatText.text = newBoatPrize.ToString();
        rodText.text = newRodPrize.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            panel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        panel.SetActive(false);
    }

    public void NewBoat()
    {
        if(CashManager.instance.totalCash >=  newBoatPrize)
        {
            CashManager.instance.totalCash -= newBoatPrize;
            boats[count].SetActive(false);
            boats[count+1].SetActive(true);
            count++;
            boatRodCount = boatMaxRodCount;
            boatMaxRodCount += 2;
            newBoatPrize += 600;
            newRodPrize += 300;
            boatText.text = newBoatPrize.ToString();
            rodText.text = newRodPrize.ToString();
        }
    }

    public void AddRod()
    {
        if(boatMaxRodCount > boatRodCount && CashManager.instance.totalCash >= newRodPrize)
        {
            CashManager.instance.totalCash -= newRodPrize;
            boats[count].transform.GetChild(boatRodCount).gameObject.SetActive(true);
            boatRodCount++;
        }
    }
}
