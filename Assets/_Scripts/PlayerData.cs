using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData 
{
    public string playerName;
    public int playerID;
    [SerializeField] private float _coins = 1000;
    public float Coins
    {
        get { return _coins; }
        set
        {
            if (_coins != value)
            {
                _coins = value;
                OnCoinValueChanged?.Invoke(_coins);
            }
        }
    }
    [SerializeField]  private float _coinsInBank = 3000;
    public float CoinsInBank
    {
        get { return _coinsInBank; }
        set
        {
            if (_coinsInBank != value)
            {
                _coinsInBank = value;
                OnCoinBankValueChanged?.Invoke(_coinsInBank);
            }
        }
    }
    public bool isSleeping;

    public event Action<float> OnCoinValueChanged;
    public event Action<float> OnCoinBankValueChanged;
}
