using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public PlayerMove Player;
    public GameObject Playerpos;
    void Start()
    {
        Playerpos = GameObject.Find("Player");
        Player = Playerpos.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player.Health -= 5;
        }
    }
}
