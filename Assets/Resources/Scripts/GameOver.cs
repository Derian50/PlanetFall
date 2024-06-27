using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textWave;
    [SerializeField] private TextMeshProUGUI prize_1;
    [SerializeField] private TextMeshProUGUI prize_2;
    [SerializeField] private TextMeshProUGUI prize_3;
    [SerializeField] private TextMeshProUGUI superPrize;

    private string[] _randomizePerksString = new string[3];
    private float[] _randomizePerksValue = new float[3];
    private string[] _randomizePerksPrefix = new string[3];
    private int[] _randomInts = {-1, -1, -1};

    private string[] _perksArr = 
    { 
        "UI/Perks/Damage", 
        "UI/Perks/AttackSpeed",
        "UI/Perks/CritChance",
        "UI/Perks/CritKoef",
        "UI/Perks/Range",
        "UI/Perks/DamageMetr",
        "UI/Perks/MultishotChance",
        "UI/Perks/MultishotTargets",
        "UI/Perks/Health",
        "UI/Perks/HealthRegen",
        "UI/Perks/MoneyCoef",
        "UI/Perks/MoneyPerWave"
    };
    private float[] _perksValue =
    {
        5f,
        0.05f,
        1f,
        0.1f,
        0.1f,
        1f,
        1f,
        1f,
        5f,
        0.5f,
        0.01f,
        5f
    };
    private string[] _perksPrefix = {"", "", "%", "", "m", "%/m", "%", "", "", "", "",""};
    private void Start()
    {

        textWave.text = GameStats.instance.wave + " " + textWave.text;

        randomizeInts();
        randomizePerks();
        showPerks();
    }
    private void randomizeInts()
    {
        int index = 0;

        while (index < 3)
        {
            int randomNumber = Random.Range(0, _perksValue.Length);
            if (!_randomInts.Contains(randomNumber))
            {
                _randomInts[index] = randomNumber;
                index++;
            }
        }
        
    }
    private void randomizePerks()
    {
        for(int i = 0; i < _randomizePerksString.Length; i++)
        {
            
            
            _randomizePerksString[i] = _perksArr[_randomInts[i]];
            _randomizePerksValue[i] = _perksValue[_randomInts[i]] * Mathf.Ceil(GameStats.instance.wave / 5);
            _randomizePerksPrefix[i] = _perksPrefix[_randomInts[i]];
        }
    }
    private void showPerks()
    {
        prize_1.GetComponent<LocalizeString>()._localizeKey = _randomizePerksString[0];
        prize_1.GetComponent<LocalizeString>().updateText();
        prize_1.text = "+" + _randomizePerksValue[0] + _randomizePerksPrefix[0] + " " + prize_1.text;
        prize_2.GetComponent<LocalizeString>()._localizeKey = _randomizePerksString[1];
        prize_2.GetComponent<LocalizeString>().updateText();
        prize_2.text = "+" + _randomizePerksValue[1] + _randomizePerksPrefix[1] + " " + prize_2.text;
        prize_3.GetComponent<LocalizeString>()._localizeKey = _randomizePerksString[2];
        prize_3.GetComponent<LocalizeString>().updateText();
        prize_3.text = "+" + _randomizePerksValue[2] + _randomizePerksPrefix[2] + " " + prize_3.text;
    }
    private void addValueToStats(int index)
    {
        switch (_randomInts[index])
        {
            case 0:
                GameStats.instance.damageStart += _randomizePerksValue[index];
                break;
            case 1:
                GameStats.instance.atackSpeedStart += _randomizePerksValue[index];
                break;
            case 2:
                GameStats.instance.critChanceStart += _randomizePerksValue[index];
                break;
            case 3:
                GameStats.instance.critDamageStart += _randomizePerksValue[index];
                break;
            case 4:
                GameStats.instance.rangeStart += _randomizePerksValue[index];
                break;
            case 5:
                GameStats.instance.damageDistanceStart += _randomizePerksValue[index];
                break;
            case 6:
                GameStats.instance.multishotChanceStart += _randomizePerksValue[index];
                break;
            case 7:
                GameStats.instance.multishotTargetsStart += _randomizePerksValue[index];
                break;
            case 8:
                GameStats.instance.HpStart += _randomizePerksValue[index];
                break;
            case 9:
                GameStats.instance.hpRegenStart += _randomizePerksValue[index];
                break;
            case 10:
                GameStats.instance.moneyCoefStart += _randomizePerksValue[index];
                break;
            case 11:
                GameStats.instance.moneyPerWaveStart += _randomizePerksValue[index];
                break;
        }
    }
    public void choiceFirstPrize()
    {
        addValueToStats(0);
        GameStats.instance.restartStats();

        YaSDK.ShowFullscreenAdv();
        //  this.gameObject.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void choiceSecondPrize()
    {
        addValueToStats(1);
        GameStats.instance.restartStats();
        YaSDK.ShowFullscreenAdv();
        //  this.gameObject.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void choiceThirdPrize()
    {
        addValueToStats(2);
        GameStats.instance.restartStats();
        YaSDK.ShowFullscreenAdv();
        // this.gameObject.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void choiceSuperPrize()
    {
        YaSDK.ShowRewardedVideo(onClose: () =>
        {
            if (YaSDK._isRewarded)
                GameStats.instance.maxTimeScale += 0.5f;
                GameStats.instance.restartStats();
                SceneManager.LoadScene("Game");
        });
        
    }
}
