using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RapidFire : MonoBehaviour
{
    public GameObject Texts;
    public string Text;
    public TextMeshProUGUI TextComp;

    
    void Awake()
    {
       // Texts = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
       Texts = GameObject.Find(Text);
       TextComp = Texts.GetComponent<TextMeshProUGUI>();
       TextComp.enabled = false;
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
            TextComp.enabled = true;
        }
    }
        void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TextComp.enabled = false;
        }
    }
}
