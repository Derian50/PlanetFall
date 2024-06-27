using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILocalMoney : MonoBehaviour
{
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        text.text = "$ " + Math.Round(GameStats.instance.localMoney).ToString();
    }
}
