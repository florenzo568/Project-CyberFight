using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject Play;
    private Vector2 Playpos;
    public float Speed;
    public double Health;
    public double StartHealth;
    public PlayerMove Player;
    public GameObject Playerpos;
    public float Damage;
    public double BulletDamage = 5;
    public bool Burn = false;
    public float BurnTick = 2f;
    public float BurnTickStart = 2f;
    public double BurnDamage = 3;
    void Start()
    {
        Playerpos = GameObject.Find("Player");
        Player = Playerpos.GetComponent<PlayerMove>();
        StartHealth = Health;
        BurnTickStart = BurnTick;
    }

    // Update is called once per frame
    void Update()
    {
        float step = Speed * Time.deltaTime;
        if (Playerpos != null)
        {
            Playpos = new Vector2(Playerpos.transform.position.x, Playerpos.transform.position.y);
        }

        transform.position = Vector2.MoveTowards(transform.position, Playpos, step);
        if (Health <= 10)
        {
            Destroy(gameObject);
        }
        if (Burn == true)
        {
            BurnTick -= Time.deltaTime;
        }
        if(BurnTick <= 0)
        {
            Health -= BurnDamage;
            BurnTick = BurnTickStart;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Health -= BulletDamage;
            if(Player.Burn == true)
            {
                Burn = true;
            }
        }
        if(other.gameObject.CompareTag("Player"))
        {
            Player.Health -= Damage;
        }
    }
}
