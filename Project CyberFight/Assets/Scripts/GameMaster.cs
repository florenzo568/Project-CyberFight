using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject CurrentTiles;
    public bool CanPlace;
    public List<GameObject> Tiles;
    public List<string> TileNames;
    public CountDownTimer Timer;
    public bool Kill;
    public GameObject Player;
    public GameObject TilesO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (CurrentTiles >= 4)
        {
            CanPlace = false;
        }*/       
        if (Timer.Shop == true)
        {
            //Kill = true;
            //Kill = false;
            for (int i  = 0; i < Tiles.Count; i++)
            {   if (Tiles[i] != null)
                {
                    if(Tiles[i].transform.position != CurrentTiles.transform.position)
                    {
                        Destroy(Tiles[i].gameObject);
                        Tiles.Remove(Tiles[i]);
                        Debug.Log("Cleared");
                    }
                }
            }
            for (int x  = 0; x < Tiles.Count; x++)
            {   if (Tiles[x] != null)
                {
                    Instantiate(TilesO, new Vector2(Tiles[x].transform.position.x - 10, Tiles[x].transform.position.y), Quaternion.identity);
                }
            }/*
            for (int i  = 0; i < Tiles.Count; i++)
            {   if (Tiles[i] != null)
                {
                    if(Tiles[i].transform.position != CurrentTiles.transform.position)
                    {
                        Destroy(Tiles[i].gameObject);
                        Tiles.Remove(Tiles[i]);
                        Debug.Log("Cleared");
                    }
                }
            }*/


            for (int i= 0; i < TileNames.Count; i++)
            {
                for(int j = 0; j < TileNames.Count; j++)
                {
                    if(TileNames[i] == TileNames[j])
                    {
                        GameObject TBD =  GameObject.Find(TileNames[j]);
                        TileNames.Remove(TileNames[j]);    
                        Destroy(TBD.gameObject);                        
                    }
                }
            }
            
        }
    }
        /*void KillTiles()
    {
         for (int i = 0; i < Tilesnew.Count; i++)
            {
                if (newTile.transform.position == Tilesnew[i].transform.position)
                {
                    Destroy(Tilesnew[i]);
                    Tilesnew.Remove(Tilesnew[i]);
                    Debug.Log("Cleared");
                }
            }
    }*/
}
