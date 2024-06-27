using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackAreaManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damageValueTMP;
    [SerializeField] private TextMeshProUGUI damageCostValueTMP;

    [SerializeField] private TextMeshProUGUI attackSpeedValueTMP;
    [SerializeField] private TextMeshProUGUI attackSpeedCostValueTMP;

    [SerializeField] private TextMeshProUGUI criteChanceValueTMP;
    [SerializeField] private TextMeshProUGUI criteChanceCostValueTMP;

    [SerializeField] private TextMeshProUGUI criteDamageValueTMP;
    [SerializeField] private TextMeshProUGUI criteDamageCostValueTMP;

    [SerializeField] private TextMeshProUGUI rangeValueTMP;
    [SerializeField] private TextMeshProUGUI rangeCostValueTMP;

    [SerializeField] private TextMeshProUGUI damageDistanceValueTMP;
    [SerializeField] private TextMeshProUGUI damageDistanceCostValueTMP;

    [SerializeField] private TextMeshProUGUI multishotChanceValueTMP;
    [SerializeField] private TextMeshProUGUI multishotChanceCostValueTMP;

    [SerializeField] private TextMeshProUGUI multishotTargetsValueTMP;
    [SerializeField] private TextMeshProUGUI multishotTargetsCostValueTMP;
    private void updateInfo()
    {
        damageValueTMP.text = Math.Round(GameStats.instance.damage).ToString();
        damageCostValueTMP.text = "$ " + Math.Round(GameStats.instance.damageCost).ToString();

        attackSpeedValueTMP.text = (Mathf.Round(GameStats.instance.atackSpeed * 100.0f) * 0.01f).ToString();
        attackSpeedCostValueTMP.text = "$ " + Math.Round(GameStats.instance.atackSpeedCost).ToString();

        criteChanceValueTMP.text = (Mathf.Round(GameStats.instance.critChance * 100.0f)).ToString() + "%";
        criteChanceCostValueTMP.text = "$ " + Math.Round(GameStats.instance.critChanceCost).ToString();

        criteDamageValueTMP.text = "x" + (Mathf.Round(GameStats.instance.critDamage * 100.0f) * 0.01f).ToString();
        criteDamageCostValueTMP.text = "$ " + Math.Round(GameStats.instance.critDamageCost).ToString();

        rangeValueTMP.text = (Math.Round(GameStats.instance.range*100)/100).ToString() + "m";
        rangeCostValueTMP.text = "$ " + Math.Round(GameStats.instance.rangeCost).ToString();

        damageDistanceValueTMP.text = (Mathf.Round(GameStats.instance.damageDistance * 100.0f) * 0.01f).ToString() + "%/m";
        damageDistanceCostValueTMP.text = "$ " + Math.Round(GameStats.instance.damageDistanceCost).ToString();

        multishotChanceValueTMP.text = (Mathf.Round(GameStats.instance.multishotChance * 100.0f) * 0.01f).ToString() + "%";
        multishotChanceCostValueTMP.text = "$ " + Math.Round(GameStats.instance.multishotChanceCost).ToString();

        multishotTargetsValueTMP.text = (Mathf.Round(GameStats.instance.multishotTargets * 100.0f) * 0.01f).ToString();
        multishotTargetsCostValueTMP.text = "$ " + Math.Round(GameStats.instance.multishotTargetsCost).ToString();
    }
    private void Start()
    {
        updateInfo();
    }
    public void tryBuyDamage()
    {
        if(GameStats.instance.localMoney >= GameStats.instance.damageCost)
        {
            GameStats.instance.localMoney -= GameStats.instance.damageCost;
            GameStats.instance.damage += 4.5f;
            GameStats.instance.damageCost += GameStats.instance.damageLevel++ + 2;
            updateInfo();
        }
    }
    public void tryBuyAttackSpeed()
    {
        if (GameStats.instance.localMoney >= GameStats.instance.atackSpeedCost)
        {
            GameStats.instance.localMoney -= GameStats.instance.atackSpeedCost;
            GameStats.instance.atackSpeed += 0.05f;
            GameStats.instance.atackSpeedCost += GameStats.instance.atackSpeedLevel++ + 2;
            updateInfo();
        }
    }
    public void tryBuyCritChance()
    {
        if (GameStats.instance.localMoney >= GameStats.instance.critChanceCost)
        {
            GameStats.instance.localMoney -= GameStats.instance.critChanceCost;
            GameStats.instance.critChance += 0.01f;
            GameStats.instance.critChanceCost += GameStats.instance.critChanceLevel++ + 2;
            updateInfo();
        }
    }
    public void tryBuyCritDamage()
    {
        if (GameStats.instance.localMoney >= GameStats.instance.critDamageCost)
        {
            GameStats.instance.localMoney -= GameStats.instance.critDamageCost;
            GameStats.instance.critDamage += 0.05f;
            GameStats.instance.critDamageCost += GameStats.instance.critDamageLevel++ + 2;
            updateInfo();
        }
    }
    public void tryBuyRange()
    {
        if (GameStats.instance.localMoney >= GameStats.instance.rangeCost)
        {
            GameStats.instance.localMoney -= GameStats.instance.rangeCost;
            GameStats.instance.range += 0.05f;
            GameStats.instance.rangeCost += GameStats.instance.rangeLevel++ + 2;
            updateInfo();
        }
    }
    public void tryBuyDamageDistance()
    {
        if (GameStats.instance.localMoney >= GameStats.instance.damageDistanceCost)
        {
            GameStats.instance.localMoney -= GameStats.instance.damageDistanceCost;
            GameStats.instance.damageDistance += 1;
            GameStats.instance.damageDistanceCost += GameStats.instance.damageDistanceLevel++ + 2;
            updateInfo();
        }
    }
    public void tryBuyMultishotChanceDistance()
    {
        if (GameStats.instance.localMoney >= GameStats.instance.multishotChanceCost)
        {
            GameStats.instance.localMoney -= GameStats.instance.multishotChanceCost;
            GameStats.instance.multishotChance += 1;
            GameStats.instance.multishotChanceCost += GameStats.instance.multishotChanceLevel++ + 2;
            updateInfo();
        }
    }
    public void tryBuyMultishotTargetsDistance()
    {
        if (GameStats.instance.localMoney >= GameStats.instance.multishotTargetsCost)
        {
            GameStats.instance.localMoney -= GameStats.instance.multishotTargetsCost;
            GameStats.instance.multishotTargets += 1;
            GameStats.instance.multishotTargetsCost *= 2f;
            updateInfo();
        }
    }
}
