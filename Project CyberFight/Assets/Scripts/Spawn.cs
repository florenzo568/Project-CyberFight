using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] SpawnPoints;
    [SerializeField] GameObject[] Enemy;
    public bool Spawns = false;
    public float SpawnTime = 1f;
    private int randomEnemy;
    private int randomSpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnNow();
    }

    void SpawnNow()
    {
        randomEnemy = Random.Range(0, Enemy.Length);
        randomSpawn = Random.Range(0, SpawnPoints.Length);

        if (Spawns == true)
        {
            Instantiate(Enemy[randomEnemy], SpawnPoints[randomSpawn].transform.position, Quaternion.identity);
            Spawns = false;
        }
    }
}
