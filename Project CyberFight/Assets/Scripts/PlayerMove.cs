using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rb;
    private Vector2 dir;
    public int Health;
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            Inputs();





        }
        
    }
    
    void FixedUpdate()
    {
        if (Player != null)
        {
            Move();




        }
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Health -= 1;
        }
        if (Health <= 0)
        {
           Debug.Log("Dead");
            if (Player != null)
            {
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
