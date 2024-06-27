using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EconomicAreaManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyCoefValueTMP;
    [SerializeField] private TextMeshProUGUI moneyCoefCostValueTMP;

    [SerializeField] private TextMeshProUGUI moneyPerWaveValueTMP;
    [SerializeField] private TextMeshProUGUI moneyPerWaveCostValueTMP;
    void Start()
    {
        updateInfo();
    }

    // Update is called once per frame
    void updateInfo()
    {
        moneyPerWaveValueTMP.text = Mathf.Round(GameStats.instance.moneyPerWave).ToString();
        moneyPerWaveCostValueTMP.text = "$ " + Math.Round(GameStats.instance.moneyPerWaveCost).ToString();

        moneyCoefValueTMP.text = "x" + (Mathf.Round(GameStats.instance.moneyCoef * 100.0f) * 0.01f).ToString();
        moneyCoefCostValueTMP.text = "$ " + Math.Round(GameStats.instance.moneyCoefCost).ToString();
    }
    public void tryBuyMoneyCoef()
    {
        if (GameStats.instance.localMoney >= GameStats.instance.moneyCoefCost)
        {
            GameStats.instance.localMoney -= GameStats.instance.moneyCoefCost;
            GameStats.instance.moneyCoef += 0.01f;
            GameStats.instance.moneyCoefCost += GameStats.instance.moneyCoefLevel++ + 2;
            updateInfo();
        }
    }
    public void tryBuyMoneyPerWave()
    {
        if (GameStats.instance.localMoney >= GameStats.instance.moneyPerWaveCost)
        {
            GameStats.instance.localMoney -= GameStats.instance.moneyPerWaveCost;
            GameStats.instance.moneyPerWave += 5f;
            GameStats.instance.moneyPerWaveCost += GameStats.instance.moneyPerWaveLevel++ + 2;
            updateInfo();
        }
    }
}
