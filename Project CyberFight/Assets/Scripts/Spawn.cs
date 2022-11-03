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
    public float StartTime = 1f;
    private int randomEnemy;
    private int randomSpawn;
    public bool SpawningEnemies = true;
    public WaveManager Waves;
    private int WaveNumber;
    public bool Kill = false;
    public PlayerMove Player;
    public GameObject Playerpos;


    void Start()
    {
        Playerpos = GameObject.Find("Player");
        Player = Playerpos.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnNow();
        SpawnTimer();
        WaveNumber = Waves.Wave;
        KillAll();
        
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
            EnemyStats.StartHealth = EnemyStats.StartHealth + (WaveNumber * 10);
            if(Player.Shield == true)
            {
                EnemyStats.Damage = (10.0f / 1.15f) + (WaveNumber * 4.0f);
            }
            else
            {
                EnemyStats.Damage = 10 + (WaveNumber * 4);
            }
            
            if(Player.FMJ == true)
            {
                EnemyStats.BulletDamage = 5 * 3;
            }
            else
            {
                EnemyStats.BulletDamage = 5;
            }
            
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
    void KillAll()
    {
        if(Kill == true)
        {
            if(Enemyinstances != null)
            {
                for (int i = 0; i < Enemyinstances.Count; i++)
                {
                    Destroy(Enemyinstances[i].gameObject);
                }
                Enemyinstances.Clear();
            }
        }
    }
}
