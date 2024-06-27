using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnedEnemies;
    private GameObject spawnedEnemy;
    [SerializeField] private GameObject bossEnemy;

    [SerializeField]
    private Transform corner_1, corner_2, corner_3, corner_4;

    public float spawnInterval;
    private float spawnProgressiveInterval;
    private int randomIndex;
    private int randomSide;
    private int randomEnemy;
    void Start()
    {
        StartCoroutine(SpawnMonsters());
        //Time.timeScale = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void spawnBossAsteroid()
    {
        randomSide = Random.Range(0, 4);  // 0 — down; 1 — right; 2 — up; 3 — left
        randomEnemy = Random.Range(0, spawnedEnemies.Length);

        spawnedEnemy = Instantiate(bossEnemy);
        Debug.Log("BOSS HP " + spawnedEnemy.GetComponent<Asteroid>()._hp);

        switch (randomSide)
        {
            case 0:
                spawnedEnemy.transform.position = new Vector2(Random.Range(corner_1.position.x, corner_2.position.x), Random.Range(corner_1.position.y, corner_2.position.y));
                break;
            case 1:
                spawnedEnemy.transform.position = new Vector2(Random.Range(corner_2.position.x, corner_3.position.x), Random.Range(corner_2.position.y, corner_3.position.y));
                break;
            case 2:
                spawnedEnemy.transform.position = new Vector2(Random.Range(corner_3.position.x, corner_4.position.x), Random.Range(corner_3.position.y, corner_4.position.y));
                break;
            case 3:
                spawnedEnemy.transform.position = new Vector2(Random.Range(corner_4.position.x, corner_1.position.x), Random.Range(corner_4.position.y, corner_1.position.y));
                break;
        }
    }
    IEnumerator SpawnMonsters()
    {

        while (true)
        {
            spawnProgressiveInterval = spawnInterval - GameStats.instance.wave / 50f;
            if (spawnProgressiveInterval < 0.3f) spawnProgressiveInterval = 0.3f;
            yield return new WaitForSeconds(Random.Range(spawnProgressiveInterval, spawnProgressiveInterval * 2));

            randomSide = Random.Range(0, 4);  // 0 — down; 1 — right; 2 — up; 3 — left
            randomEnemy = Random.Range(0, spawnedEnemies.Length);

            spawnedEnemy = Instantiate(spawnedEnemies[randomEnemy]);


            switch (randomSide)
            {
                case 0:
                    spawnedEnemy.transform.position = new Vector2(Random.Range(corner_1.position.x, corner_2.position.x), Random.Range(corner_1.position.y, corner_2.position.y));
                    break;
                case 1:
                    spawnedEnemy.transform.position = new Vector2(Random.Range(corner_2.position.x, corner_3.position.x), Random.Range(corner_2.position.y, corner_3.position.y));
                    break;
                case 2:
                    spawnedEnemy.transform.position = new Vector2(Random.Range(corner_3.position.x, corner_4.position.x), Random.Range(corner_3.position.y, corner_4.position.y));
                    break;
                case 3:
                    spawnedEnemy.transform.position = new Vector2(Random.Range(corner_4.position.x, corner_1.position.x), Random.Range(corner_4.position.y, corner_1.position.y));
                    break;
            }

        }

    }
}
