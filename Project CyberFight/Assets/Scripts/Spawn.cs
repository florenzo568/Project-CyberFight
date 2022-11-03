using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] SpawnPoints;
    [SerializeField] GameObject[] Enemy;
    public List <GameObject> Enemyinstances;
    public bool Spawns = false;
    public float SpawnTime = .5f;
    public float StartTime = .5f;
    private int randomEnemy;
    private int randomSpawn;
    public bool SpawningEnemies = true;
    public WaveManager Waves;
    private int WaveNumber;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnNow();
        SpawnTimer();
        WaveNumber = Waves.Wave;
    }

    void SpawnNow()
    {
        randomEnemy = Random.Range(0, Enemy.Length);
        randomSpawn = Random.Range(0, SpawnPoints.Length);

        if (Spawns == true)
        {
            GameObject newEnem = Instantiate(Enemy[randomEnemy], SpawnPoints[randomSpawn].transform.position, Quaternion.identity);
            Enemyinstances.Add(newEnem);
            Enemy EnemyStats = newEnem.GetComponent<Enemy>();
            EnemyStats.Health = 15 + (WaveNumber * 10);
            EnemyStats.Damage = 10 + (WaveNumber * 4);
            Spawns = false;
            SpawnTime = StartTime;
        }
    }

    void SpawnTimer()
    {
        if(SpawningEnemies == true)
        {
            SpawnTime -= Time.deltaTime;
            if(SpawnTime <= 0)
            {
                Spawns = true;
            }
        }
    }
}
