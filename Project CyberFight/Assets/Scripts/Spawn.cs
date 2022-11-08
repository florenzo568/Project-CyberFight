using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] SpawnPoints;
    [SerializeField] GameObject[] Enemy;
    [SerializeField] GameObject[] Boss;
    private GameObject newBoss;
    private Enemy EnemyStats;
    private Enemy BossStats;
    public List <GameObject> Enemyinstances;
    public bool Spawns = false;
    public float SpawnTime = 1f;
    public float StartTime = 1f;
    private int randomEnemy;
    private int randomSpawn;
    private int randomBoss;
    public bool SpawningEnemies = true;
    public bool BossAlive;
    public WaveManager Waves;
    private int WaveNumber;
    public bool Kill = false;
    public PlayerMove Player;
    public GameObject Playerpos;
    public bool BossWave = false;
    public bool BossWaveSpawn = false;
    public GameObject Final1;
    public GameObject Final2;
    public Enemy BossStatsFinal1;
    public Enemy BossStatsFinal2;
    private int EndGame;


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
        if(BossAlive == true && newBoss == null)
        {
            Waves.Shop = true;
            BossAlive = false;
            SpawningEnemies = false;
            Kill = true;
            Player.Health = Player.StartHealth;
        }
        if(Waves.BossWave == true)
        {
            BossWave = true;
            BossWaveSpawn = true;
            Waves.BossWave = false;
        }
        if(BossWave == true && BossStatsFinal1 == null && BossStatsFinal2 == null)
        {
            Debug.Log("End Game");
            EndGame += 1;
            if (EndGame > 1)
            {
                Debug.Log("EndGame FR NOW");
            }
        }
        
    }

    void SpawnNow()
    {
        randomEnemy = Random.Range(0, Enemy.Length);
        randomSpawn = Random.Range(0, SpawnPoints.Length);
        randomBoss = Random.Range(0,Boss.Length);

        if (Spawns == true)
        {
            GameObject newEnem = Instantiate(Enemy[randomEnemy], SpawnPoints[randomSpawn].transform.position, Quaternion.identity);
            Enemyinstances.Add(newEnem);
            EnemyStats = newEnem.GetComponent<Enemy>();
            EnemyStats.StartHealth = EnemyStats.StartHealth + (WaveNumber * 10);
            EnemyStats.Health = EnemyStats.Health + (WaveNumber * 10);
            if(Player.Shield == true)
            {
                EnemyStats.Damage = (EnemyStats.Damage / 1.15f) + (WaveNumber * 4.0f);
            }
            else
            {
                EnemyStats.Damage = EnemyStats.Damage + (WaveNumber * 4.0f);
            }
            
            if(Player.FMJ == true)
            {
                EnemyStats.BulletDamage = EnemyStats.BulletDamage * 3;
            }
            else
            {
                EnemyStats.BulletDamage = EnemyStats.BulletDamage;
            }
            if(Player.Hack == true)
            {
                EnemyStats.Speed = EnemyStats.Speed/2;
            }
            
            Spawns = false;
            SpawnTime = StartTime;
        }
        if (Waves.Boss == true)
        {
            newBoss = Instantiate(Boss[randomBoss], SpawnPoints[randomSpawn].transform.position, Quaternion.identity);
            Enemyinstances.Add(newBoss);
            BossStats = newBoss.GetComponent<Enemy>();
            Waves.Boss = false;
            BossAlive = true;
        }
        if(BossWave == true)
        {
            SpawningEnemies = false;

        }
        if (BossWaveSpawn == true)
            {
                Final1 = Instantiate(Boss[randomBoss], SpawnPoints[randomSpawn].transform.position, Quaternion.identity);
                Enemyinstances.Add(Final1);
                BossStatsFinal1 = Final1.GetComponent<Enemy>();
                randomBoss = Random.Range(0,Boss.Length);
                randomSpawn = Random.Range(0, SpawnPoints.Length);
                Final2 = Instantiate(Boss[randomBoss], SpawnPoints[randomSpawn].transform.position, Quaternion.identity);
                Enemyinstances.Add(Final2);
                BossStatsFinal2 = Final2.GetComponent<Enemy>();
                BossWaveSpawn = false;
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
