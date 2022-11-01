using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int CurrentTiles = 1;
    public bool CanPlace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTiles >= 4)
        {
            CanPlace = false;
        }
    }
}
