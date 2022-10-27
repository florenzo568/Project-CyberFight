using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Play;
    private Vector2 Playpos;
    public float Speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = Speed * Time.deltaTime;
        if (Play != null)
        {
            Playpos = new Vector2(Play.transform.position.x, Play.transform.position.y);
        }

        transform.position = Vector2.MoveTowards(transform.position, Playpos, step);
    }
}
