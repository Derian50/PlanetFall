using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefenceAreaManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI HpValueTMP;
    [SerializeField] private TextMeshProUGUI HpCostValueTMP;

    [SerializeField] private TextMeshProUGUI HpRegenValueTMP;
    [SerializeField] private TextMeshProUGUI HpRegenCostValueTMP;
    void Start()
    {
        updateInfo();
    }

    // Update is called once per frame
    void updateInfo()
    {
        HpValueTMP.text = Math.Round(GameStats.instance.maxHp).ToString();
        HpCostValueTMP.text = "$ " + Math.Round(GameStats.instance.HpCost).ToString();

        HpRegenValueTMP.text = (Mathf.Round(GameStats.instance.hpRegen * 100.0f) * 0.01f).ToString();
        HpRegenCostValueTMP.text = "$ " + Math.Round(GameStats.instance.hpRegenCost).ToString();
    }

    public void tryBuyHp()
    {
        if (GameStats.instance.localMoney >= GameStats.instance.HpCost)
        {
            GameStats.instance.localMoney -= GameStats.instance.HpCost;
            GameStats.instance.currentHp += 5f;
            GameStats.instance.maxHp += 5f;
            GameStats.instance.HpCost += GameStats.instance.HpLevel++ + 2;
            updateInfo();
        }
    }
    public void tryBuyRegenHp()
    {
        if (GameStats.instance.localMoney >= GameStats.instance.hpRegenCost)
        {
            GameStats.instance.localMoney -= GameStats.instance.hpRegenCost;
            GameStats.instance.hpRegen += 0.045f;
            GameStats.instance.hpRegenCost += GameStats.instance.hpRegenLevel++ + 2;
            updateInfo();
        }
    }
}
