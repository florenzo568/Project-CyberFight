using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rb;
    public Vector2 dir;
    public int Health;
    public GameObject Player;
    public bool Spawn = false;
    [SerializeField] GameObject Projectile;
    public float FireRate = 1.0f;
    public float FireRatereset;
    public Vector2 lastdir;
    public Transform firePoint;
    public float moveX;
    public float moveY;
    public bool facingRight;


    void Start()
    {
        FireRatereset = FireRate;
    }

    // Update is called once per frame
    void Update()
    {
        FireRate = FireRate - Time.deltaTime;
        Inputs();
        Shoot1();
        //Debug.Log(dir);
        if (dir.x > 0 && moveX != 0)
        {
            facingRight = true;
        }
        else if(dir.x < 0 && moveX != 0)
        {
            facingRight = false;
        }
        
    }
    
    void FixedUpdate()
    {

       Move();
       

    }

    void Inputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        dir = new Vector2(moveX, moveY).normalized;
        if(dir.x != 0 && dir.y != 0)
        {
            lastdir = dir;
        }
        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        if (moveX < 0 && facingRight)
        {
            Flip();
        }
    }
    void Move()
    {
        rb.velocity = new Vector2(dir.x * Speed, dir.y * Speed);
    }
    void Shoot1()
    {
        if(FireRate <= 0){
        Instantiate(Projectile, firePoint.position, transform.rotation);
        FireRate = FireRatereset;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy1"))
        {
            Health -= 10;
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
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
