using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Levelload : MonoBehaviour
{
    public GameObject Player;
    public GameObject Tiles;
    //public GameObject[] Tilecheck;
    public List<GameObject> Tilesnew;
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
        if (Tilesnew.Count > 2 && Tilesnew.Count < 0)
        {
            Destroy(Tilesnew[3]);
            Tilesnew.RemoveAt(3);
            Destroy(Tilesnew[4]);
            Tilesnew.RemoveAt(4);
            Destroy(Tilesnew[5]);
            Tilesnew.RemoveAt(5);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.transform.position.x > transform.position.x && other.gameObject.CompareTag("Player") && other.tag != "Ground" && Tilesnew.Count <= 3)
        {
            GameObject newTile = (GameObject)Instantiate(Tiles,Left, Quaternion.identity);
            Tilesnew.Add(newTile);
        }
        if(other.gameObject.transform.position.x < transform.position.x && other.gameObject.CompareTag("Player") && other.tag != "Ground" && Tilesnew.Count <= 3)
        {
            GameObject newTile = (GameObject)Instantiate(Tiles,Right, Quaternion.identity);
            Tilesnew.Add(newTile);
        }
        if(other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionStay2D (Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
