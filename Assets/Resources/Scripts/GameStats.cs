using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    #region GameStats

    [SerializeField] public float damageStart;
    [SerializeField] public float atackSpeedStart;
    [SerializeField] public float critChanceStart;
    [SerializeField] public float critDamageStart;
    [SerializeField] public float rangeStart;
    [SerializeField] public float damageDistanceStart;
    [SerializeField] public float multishotChanceStart;
    [SerializeField] public float multishotTargetsStart;

    [SerializeField] public float damage;
    [SerializeField] public float atackSpeed;
    [SerializeField] public float critChance;
    [SerializeField] public float critDamage;
    [SerializeField] public float range;
    [SerializeField] public float damageDistance;
    [SerializeField] public float multishotChance;
    [SerializeField] public float multishotTargets;

    [SerializeField] public float damageLevel = 1;
    [SerializeField] public float atackSpeedLevel = 1;
    [SerializeField] public float critChanceLevel = 1;
    [SerializeField] public float critDamageLevel = 1;  
    [SerializeField] public float rangeLevel = 1;
    [SerializeField] public float damageDistanceLevel = 1;
    [SerializeField] public float multishotChanceLevel = 1;
    [SerializeField] public float multishotTargetsLevel = 1;

    [SerializeField] public float damageCost;
    [SerializeField] public float atackSpeedCost;
    [SerializeField] public float critChanceCost;
    [SerializeField] public float critDamageCost;
    [SerializeField] public float rangeCost;
    [SerializeField] public float damageDistanceCost;
    [SerializeField] public float multishotChanceCost;
    [SerializeField] public float multishotTargetsCost;

    [SerializeField] public float currentHp;
    [SerializeField] public float maxHp;
    [SerializeField] public float hpRegen;

    [SerializeField] public float HpStart;
    [SerializeField] public float hpRegenStart;

    [SerializeField] public float HpCost;
    [SerializeField] public float hpRegenCost;

    [SerializeField] public float HpLevel = 1;
    [SerializeField] public float hpRegenLevel = 1;

    [SerializeField] public float moneyCoef;
    [SerializeField] public float moneyPerWave;

    [SerializeField] public float moneyCoefStart;
    [SerializeField] public float moneyPerWaveStart;

    [SerializeField] public float moneyCoefCost;
    [SerializeField] public float moneyPerWaveCost;

    [SerializeField] public float moneyCoefLevel = 1;
    [SerializeField] public float moneyPerWaveLevel =1;

    [SerializeField] public float wave;
    [SerializeField] public float enemyHp;
    [SerializeField] public float enemyAttack;

    [SerializeField] public float localMoney;
    [SerializeField] public float globalMoney;
    [SerializeField] public float moneyForKill;

    [SerializeField] public float minTimeScale;
    [SerializeField] public float maxTimeScale;
    [SerializeField] public float timeScale;

    [SerializeField] public float maxBossHp;

    public static GameStats instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
       
    }
    public void setStatsFromSave()
    {
        damageStart = SaveManager.CurrentState.damageStart;
        atackSpeedStart = SaveManager.CurrentState.atackSpeedStart;
        critChanceStart = SaveManager.CurrentState.critChanceStart;
        critDamageStart = SaveManager.CurrentState.critDamageStart;
        rangeStart = SaveManager.CurrentState.rangeStart;
        damageDistanceStart = SaveManager.CurrentState.damageDistanceStart;
        multishotChanceStart = SaveManager.CurrentState.multishotChanceStart;
        multishotTargetsStart = SaveManager.CurrentState.multishotTargetsStart;
        HpStart = SaveManager.CurrentState.HpStart;
        hpRegenStart = SaveManager.CurrentState.hpRegenStart;
        moneyCoefStart = SaveManager.CurrentState.moneyCoefStart;
        moneyPerWaveStart = SaveManager.CurrentState.moneyPerWaveStart;
        maxTimeScale = SaveManager.CurrentState.maxTimeScale;
        Debug.Log("MAXTIMESCALE " + maxTimeScale);
        Debug.Log("DAMAGESTART " + damageStart);
        restartStats();
    }
    public void restartStats()
    {
        damage = damageStart;
        atackSpeed = atackSpeedStart;
        critChance = critChanceStart;
        critDamage = critDamageStart;
        range = rangeStart;
        damageDistance = damageDistanceStart;
        multishotChance = multishotChanceStart;
        multishotTargets = multishotTargetsStart;
        maxHp = HpStart;
        currentHp = HpStart;
        hpRegen = hpRegenStart;
        moneyCoef = moneyCoefStart;
        moneyPerWave = moneyPerWaveStart;
        moneyForKill = 1;
        timeScale = 1f;
        localMoney = 0f;
        wave = 1;
        enemyHp = 2.35f;
        enemyAttack = 1.18f;
        damageCost = 5;
        atackSpeedCost = 5;
        critChanceCost = 4;
        critDamageCost = 10;
        rangeCost = 10;
        damageDistanceCost = 10;
        multishotChanceCost = 10;
        multishotTargetsCost = 120;
        HpCost = 5;
        hpRegenCost = 4;
        moneyCoefCost = 5;
        moneyPerWaveCost = 20;
        maxBossHp = 20;

        damageLevel = 1;
        atackSpeedLevel = 1;
        critChanceLevel = 1;
        critDamageLevel = 1;
        multishotChanceLevel = 1;
        multishotTargetsLevel = 1;
        HpLevel = 1;
        hpRegenLevel = 1;
        moneyCoefLevel = 1;
        moneyPerWaveLevel = 1;
        SaveManager.CurrentState.damageStart = damageStart;
        SaveManager.CurrentState.atackSpeedStart = atackSpeedStart;
        SaveManager.CurrentState.critChanceStart = critChanceStart;
        SaveManager.CurrentState.critDamageStart = critDamageStart;
        SaveManager.CurrentState.rangeStart = rangeStart;
        SaveManager.CurrentState.damageDistanceStart = damageDistanceStart;
        SaveManager.CurrentState.multishotChanceStart = multishotChanceStart;
        SaveManager.CurrentState.multishotTargetsStart = multishotTargetsStart;
        SaveManager.CurrentState.HpStart = HpStart;
        SaveManager.CurrentState.hpRegenStart = hpRegenStart;
        SaveManager.CurrentState.moneyCoefStart = moneyCoefStart;
        SaveManager.CurrentState.moneyPerWaveStart = moneyPerWaveStart;
        SaveManager.CurrentState.maxTimeScale = maxTimeScale;
        SaveManager.SaveState();
    }
    #endregion
}
