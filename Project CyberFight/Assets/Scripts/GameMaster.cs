using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject CurrentTiles;
    public bool CanPlace;
    public List<GameObject> Tiles;
    public bool Kill;
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
        if (Kill == true)
        {
            /*for (int i= 0; i < Tiles.Count; i++)
            {
                for(int j = 0; j < Tiles.Count; j++)
                {
                    if(Tiles[i] != null && Tiles[j] != null)
                    {
                        if(Tiles[i].transform.position == Tiles[j].transform.position)
                        {
                            Destroy(Tiles[i].gameObject);
                            Tiles.Remove(Tiles[i]);
                            Debug.Log("Cleared");
                        }
                    }
                }
            }*/

            for (int i  = 0; i< Tiles.Count; i++)
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
        }
    }
}
