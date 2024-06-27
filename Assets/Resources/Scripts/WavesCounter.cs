using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WavesCounter : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI damageTMP;
    [SerializeField] private TextMeshProUGUI healthTMP;
    [SerializeField] private TextMeshProUGUI waveTMP;

    [SerializeField] private float waveDuration;

    [SerializeField] private GameObject bossSlider;
    [SerializeField] private GameObject asteroidSpawner;

    private float _waveTimeCount;
    private string _waveName;

    
    private void Start()
    {
        _waveName = waveTMP.text;
        updateInfo();
    }
    private void updateInfo()
    {
        damageTMP.text = (Mathf.Round(GameStats.instance.enemyAttack * 100.0f) * 0.01f).ToString();
        healthTMP.text = (Mathf.Round(GameStats.instance.enemyHp * 100.0f) * 0.01f).ToString();
        waveTMP.text = _waveName + " " + GameStats.instance.wave.ToString();
    }
    private void FixedUpdate()
    {
        _waveTimeCount += Time.deltaTime;

        if(_waveTimeCount > waveDuration)
        {
            GameStats.instance.localMoney += GameStats.instance.moneyPerWave;
            GameStats.instance.wave++;
            GameStats.instance.enemyAttack *= 1.15f;
            GameStats.instance.enemyHp *= 1.3f;
            if(GameStats.instance.wave % 10 == 0)
            {
                GameStats.instance.moneyForKill += 1;
                GameStats.instance.maxBossHp *= 12.3f;
                spawnBoss();
            }
            updateInfo();
            _waveTimeCount = 0;
        }

        slider.value = _waveTimeCount / waveDuration;
    }
    private void spawnBoss()
    {
        asteroidSpawner.GetComponent<AsteroidSpawner>().spawnBossAsteroid();
        bossSlider.SetActive(true);
        bossSlider.GetComponent<BossSlider>().findBoss();
    }
}