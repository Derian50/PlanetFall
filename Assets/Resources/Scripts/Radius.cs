using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{

    Vector3 range;
    
    void Update()
    {
        range = new Vector3(GameStats.instance.range * 6.8f, GameStats.instance.range * 6.8f, 1);
        transform.localScale = range;
    }
}
