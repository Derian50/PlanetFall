using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScaleButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] private float minTimeScale = 0f;
    [SerializeField] private float maxTimeScale = 2f;

    private void Start()
    {
        minTimeScale = GameStats.instance.minTimeScale;
        maxTimeScale = GameStats.instance.maxTimeScale;
        changeTimeScale();
    }
    public void onClickPlusButton()
    {
        Debug.Log("maxTimeScale: " + GameStats.instance.maxTimeScale);
        if (GameStats.instance.timeScale < GameStats.instance.maxTimeScale)
        {
            GameStats.instance.timeScale += 0.5f;
        }
        changeTimeScale();

    }
    public void onClickMinusButton()
    {
        if (GameStats.instance.timeScale > GameStats.instance.minTimeScale)
        {
            GameStats.instance.timeScale -= 0.5f;
        }
        changeTimeScale();
    }
    private void changeTimeScale()
    {

        Time.timeScale = GameStats.instance.timeScale;
        text.text = "x" + GameStats.instance.timeScale.ToString();
    }
}
