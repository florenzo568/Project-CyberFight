using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rb;
    private Vector2 dir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }
    
    void FixedUpdate()
    {
        Move();
    }

    void Inputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        dir = new Vector2(moveX, moveY).normalized;
    }
    void Move()
    {
        rb.velocity = new Vector2(dir.x * Speed, dir.y * Speed);
    }
}
