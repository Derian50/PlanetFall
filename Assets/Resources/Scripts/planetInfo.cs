
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class planetInfo : MonoBehaviour
{

    [SerializeField] Slider sliderHP;
    [SerializeField] TextMeshProUGUI textHPRegen;
    [SerializeField] TextMeshProUGUI textAttack;
    [SerializeField] TextMeshProUGUI textHP;
    private float _currentHP;
    private float _maxHP;
    private float _hpRegen;
    private float _attack;
    // Start is called before the first frame update
    void Start()
    {
        updatePlanetInfo();
        StartCoroutine(HpRegen());
    }

    // Update is called once per frame
    public void updatePlanetInfo()
    {
        _currentHP = GameStats.instance.currentHp;
        _maxHP = GameStats.instance.maxHp;
        _hpRegen = GameStats.instance.hpRegen;
        _attack = GameStats.instance.damage;

        sliderHP.value = _currentHP / _maxHP;
        textHPRegen.text = (Mathf.Round(_hpRegen * 100.0f) *0.01f).ToString() + "/s";
        textAttack.text = Mathf.Round(_attack).ToString();
        textHP.text = Mathf.Ceil(_currentHP).ToString() + "/" + _maxHP.ToString();

    }
    IEnumerator HpRegen()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            GameStats.instance.currentHp += GameStats.instance.hpRegen;
            if(GameStats.instance.currentHp > GameStats.instance.maxHp)
            {
                GameStats.instance.currentHp = GameStats.instance.maxHp;
            }
        }
    }
    private void FixedUpdate()
    {
        updatePlanetInfo();
    }
}
