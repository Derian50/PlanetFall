using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

public class Shoot : MonoBehaviour
{
    public GameObject FirePoint;
    public Camera Cam;
    public float MaxLength;

    private Ray RayMouse;
    private Vector3 direction;
    private Quaternion rotation;
    [SerializeField] private GameObject Prefab;
    private float fireCountdown = 0f;

    List<Vector3> enemiesPos = new List<Vector3>();
    Vector3 nearestEnemy;

    private void Start()
    {
        StartCoroutine(searchNearEnemies());
    }

    IEnumerator searchNearEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            enemiesPos.Clear();
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (Vector3.Distance(enemy.transform.position, this.transform.position) < GameStats.instance.range)
                {
                    enemiesPos.Add(enemy.transform.position);
                }
            }
            
            enemiesPos.Sort((a, b) =>
            {
                float distanceA = Vector3.Distance(a, this.transform.position);
                float distanceB = Vector3.Distance(b, this.transform.position);
                return distanceA.CompareTo(distanceB);
            });
            if(enemiesPos.Count > 0)
            {
                nearestEnemy = enemiesPos[0];
            }
            Debug.Log(nearestEnemy);

        }

    }

    void Update()
    {
        /*Debug.Log(fireCountdown);
        Debug.Log(enemies.Count);
        Debug.Log("=====");*/
        
        if (fireCountdown <= 0f && enemiesPos.Count > 0)
        {

            if (GameStats.instance.multishotChance > Random.Range(0, 100))
            {
                for (int i = 1; i < GameStats.instance.multishotTargets; i++)
                {
                    if (enemiesPos.Count > i)
                    {
                        transform.rotation = Quaternion.LookRotation(Vector3.forward, enemiesPos[i] - transform.position);
                        Instantiate(Prefab, FirePoint.transform.position, FirePoint.transform.rotation); ;
                    }
                    
                }
            }

            //transform.LookAt(enemies[0].transform.position);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, nearestEnemy - transform.position);


            Instantiate(Prefab, FirePoint.transform.position, FirePoint.transform.rotation);
            fireCountdown = 0;
            fireCountdown += 1f / GameStats.instance.atackSpeed;
        }
        fireCountdown -= Time.deltaTime;

    }
   
}
