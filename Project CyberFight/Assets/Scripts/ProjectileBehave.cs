using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehave : MonoBehaviour
{
    public float Speed = 4.5f;
    public PlayerMove Player;
    public GameObject Playerpos;
    private Vector2 PlayerGO;
    public Vector2 Dir;
    private float LifeTime = 1.5f;
    public Rigidbody2D rb;
    public Vector3 Firedir;
    public float thrust = 18;
    public bool Right;


    void Awake()
    {
        Playerpos = GameObject.Find("Player");
        Player = Playerpos.GetComponent<PlayerMove>();
        Right = Player.facingRight;
        Vector2 Dir = new Vector2(Player.dir.x, Player.dir.y);

        if(Player.facingRight == true && Dir.x > 0)
        {
            rb.AddForce (transform.right * Speed * thrust);
        }
        if (Player.facingRight == false && Dir.x < 0)
        {
            rb.AddForce (-Vector3.right * Speed * thrust);
        }

        if (Dir.y > 0)
        {
            rb.AddForce (transform.up * Speed * thrust);
        }

        if (Dir.y < 0)
        {
            rb.AddForce (-transform.up * Speed * thrust);
        }

        if (Dir.x == 0 && Dir.y == 0 && Player.facingRight == true)
        {
            rb.AddForce (transform.right * Speed * thrust);
        }
        else if (Dir.x == 0 && Dir.y == 0 && Player.facingRight == false)
        {
            rb.AddForce (-transform.right * Speed * thrust);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {


        
        if (LifeTime >= 0 ){
        LifeTime -= Time.deltaTime;
        }
        if(LifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy1") || other.gameObject.CompareTag("Boss")){
        Destroy(gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy1") || other.gameObject.CompareTag("Boss")){
        Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);  
        }
    }

}
