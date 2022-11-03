using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] SpawnPoints;
    [SerializeField] GameObject[] Enemy;
    public List <GameObject> Enemyinstances;
    public bool Spawns = false;
    public float SpawnTime = 1f;
    private int randomEnemy;
    private int randomSpawn;
    public WaveManager Waves;
    private int WaveNumber;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnNow();
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
            EnemyStats.Health = 20 + (WaveNumber * 10);
            EnemyStats.Damage = 10 + (WaveNumber * 4);
            Spawns = false;
        }
    }
}
