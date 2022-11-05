using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : MonoBehaviour
{
    public GameObject Texts;
    public string Text;

    
    void Awake()
    {
       // Texts = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
       Texts = GameObject.Find(Text);
       Texts.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Texts.SetActive(true);
        }
    }
        void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Texts.SetActive(false);
        }
    }
}
