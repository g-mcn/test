using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public playerMvn playerHp;
    public GameObject enemy;
    public float spawnTime = 3f;
    public GameObject[] spawnPoints;
    public float SurvivalTime = 8f;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        if(spawnTime >= 0)
        {
            InvokeRepeating("LessTime", SurvivalTime, SurvivalTime);
        }
    }

    void LessTime()
    {
        spawnTime--;
    }

    void Spawn()
    {
        if (playerHp.Hp <= 0f)
        {
            return;
        }

        
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
    }
}
