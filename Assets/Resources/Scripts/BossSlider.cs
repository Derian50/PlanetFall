using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossSlider : MonoBehaviour
{
    private GameObject bossAsteroid;
    [SerializeField] private TextMeshProUGUI bossHpText;
    private Slider bossSlider;

    private void Start()
    {
        bossSlider = GetComponent<Slider>();
    }
    public void findBoss()
    {

        List<GameObject> Enemies = new List<GameObject>();
        Enemies.Clear();
        Enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        foreach (GameObject obj in Enemies)
        {
            if (obj.GetComponent<Asteroid>().isBoss)
            {
                bossAsteroid = obj;
            }
        }
        bossAsteroid.GetComponent<Asteroid>()._hp = GameStats.instance.maxBossHp;

    }
    private void FixedUpdate()
    {
        if(bossAsteroid == null)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            bossSlider.value = bossAsteroid.GetComponent<Asteroid>()._hp / GameStats.instance.maxBossHp;
            bossHpText.text = bossAsteroid.GetComponent<Asteroid>()._hp + "/" + GameStats.instance.maxBossHp;
        }
       

    }
}
