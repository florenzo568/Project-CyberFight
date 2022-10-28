using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelload : MonoBehaviour
{
    public GameObject Player;
    
    public GameObject Tiles;
    Vector2 currentTile;
    Vector2 Playerpos;
    Vector2 Left;
    Vector2 Right;

    void Awake()
    {
        currentTile = transform.position;
        Player = GameObject.Find("Player");
        Left = new Vector2(transform.position.x - 10 , transform.position.y);
        Right = new Vector2(transform.position.x + 10 , transform.position.y);
    }

    void Start()
    {
        currentTile = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Playerpos = Player.transform.position;
        Deload();
    }

    void Deload()
    {
        if(Playerpos.x - currentTile.x > 20 || Playerpos.x - currentTile.x < -20)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.transform.position.x > transform.position.x && other.gameObject.CompareTag("Player"))
        {
            Instantiate(Tiles,Left, Quaternion.identity);
        }
        if(other.gameObject.transform.position.x < transform.position.x && other.gameObject.CompareTag("Player"))
        {
            Instantiate(Tiles,Right, Quaternion.identity);
        }
    }
}
