using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float _hp;
    public GameObject explosion;
    Sequence moveSequance;
    Sequence rotationSequance;
    private GameObject _planet;
    [SerializeField] public float moneyDrop = 1;
    [SerializeField] private GameObject moneyText;
    [SerializeField] public bool isBoss;

    public UnityEvent asteroidDie;
    void Start()
    {
        moneyDrop *= GameStats.instance.moneyForKill;
        if (!isBoss)
        {
            _hp = _hp * GameStats.instance.enemyHp;
        }
        _planet = GameObject.FindGameObjectWithTag("Planet");


        //transform.localScale += new Vector3(_hp * 0.03f, _hp * 0.03f, _hp * 0.03f);

        rotationSequance = DOTween.Sequence();
        rotationSequance
            .Append(transform.DORotate(new Vector3(0, 0, 180), UnityEngine.Random.Range(10, 30)/10f)
            .SetEase(Ease.Linear))
            .SetLoops(-1, LoopType.Incremental);
        rotationSequance.Play();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _planet.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Planet")
        {
            _planet.GetComponent<Planet>().takeDamage(GameStats.instance.enemyAttack);
            if(isBoss)
            {
                _planet.GetComponent<Planet>().takeDamage(GameStats.instance.enemyAttack * 100);
            }
            died();
        }
        if (collision.gameObject.tag == "Bullet")
        {
            float distance = Vector3.Distance(transform.position, _planet.transform.position)*1.7f;
            if (GameStats.instance.critChance * 100 >= UnityEngine.Random.Range(0, 100))
            {
                _hp -= GameStats.instance.damage * GameStats.instance.critDamage * (1 + GameStats.instance.damageDistance / 100 * distance);
            }
            else
            {

                _hp -= GameStats.instance.damage * (1 + GameStats.instance.damageDistance / 100 * distance);
            }
            if (_hp <= 0)
            {
                died();
            }
        }
        if (collision.gameObject.tag == "ColdBullet")
        {
            speed = speed * 0.8f;
            if (speed <= 0.5) speed = 0.5f;
            _hp--;
            if (_hp <= 0)
            {
                died();
            }
        }

    }
    private void died()
    {
        //GetComponent<MoneyDisplay>().viewMoneyLoot(moneyDrop);
        explosion = Instantiate(explosion, transform.position, transform.rotation);
        moneyText = Instantiate(moneyText, transform.position, Quaternion.identity);
        moneyText.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "$" + moneyDrop;
        moneyText.transform.GetChild(0).GetComponent<MoneyDisplay>().money = moneyDrop;
        //moneyText.SetActive(true);
        //transform.rotation = Quaternion.identity;
        GameStats.instance.localMoney += moneyDrop * GameStats.instance.moneyCoef;

        moveSequance.Kill();
        rotationSequance.Kill();
        Destroy(explosion,2);
        Destroy(moneyText, 3);
        Destroy(gameObject);
    }
        
}
