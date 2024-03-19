using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text CoinText;
    [SerializeField] TMP_Text CoinBankText;
    [SerializeField] TMP_InputField amountInputField;

    private void Start()
    {
        CoinText.text = PlayerManager.instance.playerData.Coins.ToString();
        CoinBankText.text = PlayerManager.instance.playerData.CoinsInBank.ToString();

        PlayerManager.instance.playerData.OnCoinValueChanged += ChangeCoinUI;
        PlayerManager.instance.playerData.OnCoinBankValueChanged += ChangeCoinBankUI;

    }
    private void OnDisable()
    {
        PlayerManager.instance.playerData.OnCoinValueChanged -= ChangeCoinUI;
        PlayerManager.instance.playerData.OnCoinBankValueChanged -= ChangeCoinBankUI;
    }

    void ChangeCoinUI(float num)
    {
        CoinText.text = num.ToString("0.0");
    }

    void ChangeCoinBankUI(float num)
    {
        CoinBankText.text = num.ToString("0.0");
    }

    public void OnDepositClick()
    {
        print(Convert.ToInt32(amountInputField.text));
        CoinsManager.instance.IncreaseBankCoins(Convert.ToInt32(amountInputField.text));
    }
    public void OnWithdrawClick()
    {
        CoinsManager.instance.DecreaseBankCoins(Convert.ToInt32(amountInputField.text));
    }
    public void OnSleepClick()
    {
        float decreaseValue = Convert.ToInt32(PlayerManager.instance.playerData.CoinsInBank) * .1f;
        CoinsManager.instance.IncreaseBankCoins(decreaseValue ,false);
    }
}
