using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeachText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI teachText;
    [SerializeField] private float displayTime = 3f;
    [SerializeField] private float fadeSpeed = 1f;


    private void Start()
    {
        StartCoroutine(DisplayText());
    }

    private IEnumerator DisplayText()
    {
        float timer = 0f;

        while (timer < displayTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        float fadeTimer = 0f;
        Color textColor = teachText.color;

        while (fadeTimer < fadeSpeed)
        {
            fadeTimer += Time.deltaTime;
            textColor.a = Mathf.Lerp(1f, 0f, fadeTimer / fadeSpeed);
            teachText.color = textColor;
            yield return null;
        }

        Destroy(gameObject);
    }
}
