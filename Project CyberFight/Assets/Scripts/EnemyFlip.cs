using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{

     private SpriteRenderer spriteRenderer;
    public GameObject Playerpos;
 
     public void Awake()
     {
        Playerpos = GameObject.Find("Player");
         this.spriteRenderer = this.GetComponent<SpriteRenderer>();
     }
 
     public void Update()
     {
         this.spriteRenderer.flipX = Playerpos.transform.position.x < this.transform.position.x;
     }
 

}
