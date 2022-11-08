using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rb;
    public Vector2 dir;
    public float Health;
    public float StartHealth;
    public GameObject Player;
    public CountDownTimer Timer;
    public bool Spawn = false;
    [SerializeField] GameObject Projectile;
    [SerializeField] GameObject HeavyProjectile;
    [SerializeField] GameObject ReverseProjectile;
    [SerializeField] GameObject ThermalDetonator;
    public double FireRate = 1.0f;
    public double FireRatereset;
    public Vector2 lastdir;
    public Transform firePoint;
    public Transform ReversefirePoint;
    public float moveX;
    public float moveY;
    public bool facingRight;
    public bool RapidFire = false;
    public bool FMJ = false;
    public bool Shield = false;
    public bool Limb = false;
    public bool Hack = false;
    public bool Burn = false;
    public bool Thermal = false;
    public bool Heavy = false;
    public bool Back = false;
    private bool Active = true;


    void Start()
    {
        StartHealth = Health;
        FireRatereset = FireRate;
    }

    // Update is called once per frame
    void Update()
    {
        FireRate = FireRate - Time.deltaTime;
        Inputs();
        if(Timer.Shoptimer != true)
        {
            Shoot1();
        }
        
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
       if(dir.x > 0 && dir.y > 0)
        {
            lastdir = dir;
        }
       if (Limb == true)
        {
            Speed = Speed * 1.3f;
            Limb = false;
        }
       if (Thermal == true)
        {
            ThermalDetonator.gameObject.SetActive(true);
            Thermal = false;
        }

    }

    void Inputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        dir = new Vector2(moveX, moveY).normalized;
        
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
        if (Active == true)
        {
            rb.velocity = new Vector2(dir.x * Speed, dir.y * Speed);
        }
        
    }
    void Shoot1()
    {
        if (RapidFire == true)
        {
            FireRatereset = FireRatereset/ 1.5;
            RapidFire = false;
        }
        if(FireRate <= 0){
        GameObject newBullet = Instantiate(Projectile, firePoint.position, transform.rotation);
        ProjectileBehave newBullets = newBullet.GetComponent<ProjectileBehave>();
            if (Back == true)
            {
                Instantiate(ReverseProjectile, ReversefirePoint.position, transform.rotation);
            }
        FireRate = FireRatereset;
            if(Heavy == true)
            {
                Instantiate(HeavyProjectile, firePoint.position, transform.rotation);
            }
        }
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy1"))
        {
            Health -= 10;
        }

        if (Health <= 0)
        {
           Debug.Log("Dead");
            if (Player != null)
            {
                Death();
            }
        }
        if(other.gameObject.CompareTag("RapidFire"))
        {
            RapidFire = true;
        }
        if (other.gameObject.CompareTag("FMJ"))
        {
            FMJ = true;
        }
        if (other.gameObject.CompareTag("Shield"))
        {
            Shield = true;
        }
        if (other.gameObject.CompareTag("Limb"))
        {
            Limb = true;
        }
        if (other.gameObject.CompareTag("Hack"))
        {
            Hack = true;
        }
        if (other.gameObject.CompareTag("Burn"))
        {
            Burn = true;
        }
        if (other.gameObject.CompareTag("Thermal"))
        {
            Thermal = true;
        }
        if (other.gameObject.CompareTag("Heavy"))
        {
            Heavy = true;
        }
        if (other.gameObject.CompareTag("Back"))
        {
            Back = true;
        }

    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
    void Death()
    {
        SpriteRenderer m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        m_SpriteRenderer.enabled = false;
        //death anim + death Screen
        Active = false;
    }

    
}
