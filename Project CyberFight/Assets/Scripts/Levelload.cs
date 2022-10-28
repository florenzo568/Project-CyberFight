using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelloading : MonoBehaviour
{
    [SerializeField] GameObject Player;
    Vector2 currentTile;
    Vector2 Playerpos;

    void Awake()
    {
        currentTile = transform.position;
    }

    void Start()
    {
        
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
}
