using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Levelload : MonoBehaviour
{
    public GameObject Player;
    public GameObject Tiles;
    public GameObject Gamem;
    public GameMaster GM;
    //public GameObject[] Tilecheck;
    public List<GameObject> Tilesnew;
    Vector2 currentTile;
    Vector2 Playerpos;
    Vector2 Left;
    Vector2 Right;
    private GameObject newTile;

    void Awake()
    {
        currentTile = transform.position;
        Player = GameObject.Find("Player");
        Gamem = GameObject.Find("GM");
        GM = Gamem.GetComponent<GameMaster>();
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
        if (Player != null){
        Playerpos = Player.transform.position;
        }
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
        /*for (int i= 0; i < Tilesnew.Count; i++)
        {
            for(int j = 0; j < Tilesnew.Count; j++)
            {
                if(Tilesnew[i].transform.position == Tilesnew[j].transform.position)
                {
                    Destroy(Tilesnew[i].gameObject);
                    Tilesnew.Remove(Tilesnew[i]);
                }
            }
        }
         for (int i = 0; i < Tilesnew.Count; i++)
            {
                if (newTile.transform.position == Tilesnew[i].transform.position)
                {
                    Destroy(Tilesnew[i]);
                    Tilesnew.Remove(Tilesnew[i]);
                    Debug.Log("Cleared");
                }
            }*/
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.transform.position.x > transform.position.x && other.gameObject.CompareTag("Player") && other.tag != "Ground" && Tilesnew.Count <= 3)
        {
            newTile = (GameObject)Instantiate(Tiles,Left, Quaternion.identity);
            GM.Tiles.Add(newTile);
            GM.CurrentTiles = newTile;
           
        }
        if(other.gameObject.transform.position.x < transform.position.x && other.gameObject.CompareTag("Player") && other.tag != "Ground" && Tilesnew.Count <= 3)
        {
            newTile = (GameObject)Instantiate(Tiles,Right, Quaternion.identity);
            GM.Tiles.Add(newTile);
            GM.CurrentTiles = newTile;
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
