using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{

    [SerializeField] private GameObject upgradeMenu;
    private PlayerMovement playerMovement;
    [SerializeField] private float speed;
    private SellFish sellFish;
    [SerializeField] int fishPayment;
    [SerializeField] int capasityCash = 30;
    [SerializeField] int moneyCash = 30;
    [SerializeField] int speedCash = 50;

    [SerializeField] TextMeshProUGUI capacityText;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI speedText;

    private void Awake()
    {
        speed = FindObjectOfType<PlayerMovement>().speed;
        fishPayment = FindObjectOfType<SellFish>().fishPayment;
        capacityText.text = capasityCash.ToString();
        moneyText.text = moneyCash.ToString();
        speedText.text = speedCash.ToString();

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            upgradeMenu.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
           upgradeMenu.SetActive(true);
        }
    }

    public void CapacityButton()
    {
        if(CashManager.instance.totalCash >= capasityCash)
        {
            Fishing.instance.maxFishStorage += 5;
            CashManager.instance.totalCash -= capasityCash;
            capasityCash += 20;
            capacityText.text = capasityCash.ToString();
        }
    }

    public void MoneyButton()
    {
        if(CashManager.instance.totalCash >= moneyCash)
        {
            fishPayment += 1;
            CashManager.instance.totalCash -= moneyCash;
            moneyCash += 100;
            moneyText.text = moneyCash.ToString();
        }
    }

    public void SpeedButton()
    {
        if(CashManager.instance.totalCash >= speedCash)
        {
            speed += 0.2f;
            CashManager.instance.totalCash -= speedCash;
            speedCash += 50;
            speedText.text = speedCash.ToString();
        }
    }

}
