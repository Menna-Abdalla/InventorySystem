using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text coinText;
    [SerializeField] TMP_Text coinBankText;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_InputField ATM_AmountInputField;

    private void Start()
    {
        coinText.text = PlayerManager.instance.playerData.Coins.ToString();
        coinBankText.text = PlayerManager.instance.playerData.CoinsInBank.ToString();

        PlayerManager.instance.playerData.OnCoinValueChanged += ChangeCoinUI;
        PlayerManager.instance.playerData.OnCoinBankValueChanged += ChangeCoinBankUI;

        ATM_AmountInputField.characterValidation = TMP_InputField.CharacterValidation.Integer;

        EventsManager.eATM_Error += ShowError;
    }
    private void OnDisable()
    {
        PlayerManager.instance.playerData.OnCoinValueChanged -= ChangeCoinUI;
        PlayerManager.instance.playerData.OnCoinBankValueChanged -= ChangeCoinBankUI;

        EventsManager.eATM_Error -= ShowError;
    }

    public void OnATM_AmountInputFieldChange()
    {
        if (ATM_AmountInputField.text != "0")
        {
            if (int.Parse(ATM_AmountInputField.text) < 0)
            {
                ATM_AmountInputField.text = "0";
            }
        }
    }

    public void ShowError(string ErrorMsg)
    {
        StopCoroutine(ShowHideError());
        errorText.text = ErrorMsg;
        StartCoroutine(ShowHideError());
    }

    IEnumerator ShowHideError()
    {
        errorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        errorText.gameObject.SetActive(false);
    }
    void ChangeCoinUI(float num)
    {
        coinText.text = num.ToString("0.0");
    }

    void ChangeCoinBankUI(float num)
    {
        coinBankText.text = num.ToString("0.0");
    }

    public void OnDepositClick()
    {
        print(Convert.ToInt32(ATM_AmountInputField.text));
        CoinsManager.instance.IncreaseBankCoins(Convert.ToInt32(ATM_AmountInputField.text));
    }
    public void OnWithdrawClick()
    {
        CoinsManager.instance.DecreaseBankCoins(Convert.ToInt32(ATM_AmountInputField.text));
    }
    public void OnSleepClick()
    {
        float decreaseValue = Convert.ToInt32(PlayerManager.instance.playerData.CoinsInBank) * .1f;
        CoinsManager.instance.IncreaseBankCoins(decreaseValue, false);
    }
}
