using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject Play;
    private Vector2 Playpos;
    public float Speed;
    public int Health;
    public PlayerMove Player;
    public GameObject Playerpos;
    public int Damage;
    void Start()
    {
        Playerpos = GameObject.Find("Player");
        Player = Playerpos.GetComponent<PlayerMove>();
        Health = 20;
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
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Health -= 5;
        }
        if(other.gameObject.CompareTag("Player"))
        {
            Player.Health -= Damage;
        }
    }
}
