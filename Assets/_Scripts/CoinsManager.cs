using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager instance;
    public PlayerData playerData;
    //public event Action<int> OnValueChanged;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        
        //OnValueChanged?.Invoke(playerData.Coins);
    }
    private void Start()
    {
        playerData = PlayerManager.instance.playerData;
    }
    private void OnEnable()
    {
        EventsManager.eManageStock += GetAmountFromData;

    }

    private void OnDisable()
    {
        EventsManager.eManageStock -= GetAmountFromData;
    }
     public void GetAmountFromData(ItemData data, string process)
    {
        if(process == "purchase")
            DecreaseCoins(data.buyPrice);
        else
            IncreaseCoins(data.buyPrice);

        print(playerData.Coins + " " + data.buyPrice);
    }
    public void IncreaseCoins(float amount)
    {
        playerData.Coins += amount;
    }
    public void DecreaseCoins(float amount)
    {
        playerData.Coins -= amount;
    }
   
    public void IncreaseBankCoins(float amount, bool affectCoins = true)
    {
        if(amount<= playerData.Coins)
        {
            playerData.CoinsInBank += amount;
            if (affectCoins)
                DecreaseCoins(amount);
        }
        else
        {
            EventsManager.ATM_Error("Error player does not have enough coins!");
            print("Error player does not have enough coins"); 
        }
       
    }
    public void DecreaseBankCoins(float amount, bool affectCoins = true)
    {
        if (amount <= playerData.CoinsInBank)
        {
            playerData.CoinsInBank -= amount;
            if (affectCoins)
                IncreaseCoins(amount);
        }
        else
        {
            EventsManager.ATM_Error("Error Bank does not have enough coins!");
            print("Error Bank does not have enough coins");
        }
    }
}
