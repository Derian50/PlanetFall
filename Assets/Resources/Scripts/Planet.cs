using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject explosion;
    [SerializeField] private GameObject planetInfo;
    [SerializeField] private GameObject gameOver;
    private void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
    public void takeDamage(float damage)
    {
        GameStats.instance.currentHp -= damage;
        if(GameStats.instance.currentHp <= 0) 
        {

            Debug.Log("GAME OVER");
            gameOver.SetActive(true);
            GameStats.instance.timeScale = 0;
            Time.timeScale = 0;
        }
    }
}
