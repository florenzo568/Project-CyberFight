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
    private float LifeTime = 3;
    public Rigidbody2D rb;
    public Vector3 Firedir;
    public float thrust = 18;
    public bool Right;


    void Awake()
    {
        Playerpos = GameObject.Find("Player");
        Player = Playerpos.GetComponent<PlayerMove>();
        Right = Player.facingRight;

        if(Player.facingRight == true)
        {
            rb.AddForce (transform.right * Speed * thrust);
        }
        if (Player.facingRight == false)
        {
            rb.AddForce (-Vector3.right * Speed * thrust);
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy1")){
        Destroy(gameObject);
        }
    }

}
