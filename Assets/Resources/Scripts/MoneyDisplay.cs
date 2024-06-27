using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private float displayTime = 3f;
    [SerializeField] private float fadeSpeed = 1f;
    public float money;


    private void Start()
    {
        StartCoroutine(DisplayMoney());
    }

    private IEnumerator DisplayMoney()
    {
        moneyText.text = money.ToString() + "$";
        float timer = 0f;

        while (timer < displayTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        float fadeTimer = 0f;
        Color textColor = moneyText.color;

        while (fadeTimer < fadeSpeed)
        {
            fadeTimer += Time.deltaTime;
            textColor.a = Mathf.Lerp(1f, 0f, fadeTimer / fadeSpeed);
            moneyText.color = textColor;
            yield return null;
        }

        Destroy(gameObject);
    }
}