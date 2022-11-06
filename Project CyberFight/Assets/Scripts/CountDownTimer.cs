using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public float currentTime;
    public float startingTime;
    public float ShopTime;
    public bool Shop = false;
    public bool Shoptimer;
    public bool Boss = false;
    public bool active;
    public WaveManager Wave;
    public Spawn Spawner;
    public TextMeshProUGUI textmeshPro;
    float minutes;
    float seconds;
    public GameObject Shop1;
    public GameObject Shop2;
    private GameObject Item1;
    private GameObject Item2;
    public List<GameObject> Pool1 = new List<GameObject>();
    public List<GameObject> Pool2 = new List<GameObject>();

    void Start()
    {
        startingTime = currentTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
        Shopfoo();
        RemoveOption();
        if(currentTime < 0)
        {
            active = false;
            Boss = true;
            currentTime = startingTime;
        }
        if(Wave.Shop == true)
        {
            Shop = true;
        }
        if(Shoptimer == true)
        {
            ShopTime -= Time.deltaTime;
        }
        if(Shoptimer == true)
        {
            TimeToDisplay(ShopTime);
        }
        else
        {
            TimeToDisplay(currentTime);
        }
        
    }
    void TimeToDisplay(float time)
    {
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        textmeshPro.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void CountDown()
    {
        if (active == true)
        {
        currentTime -= Time.deltaTime;
        }
    }
    void Shopfoo()
    {
        if(Shop == true)
        {
            ShopTime = 12;
            SpawnShop();
            Shop = false;
            Shoptimer = true;
            Wave.Shop = false;
            
        }
        if (ShopTime <= 0 && Shoptimer == true)
            {
                Wave.Shop = false;
                Shoptimer = false;
                currentTime = startingTime;
                Spawner.SpawningEnemies = true;
                Spawner.Kill = false;
                active = true;
            }

    }
    void SpawnShop()
    {
        int randomPool1 = Random.Range(0, Pool1.Count);
        int randomPool2 = Random.Range(0, Pool2.Count);
        GameObject Item1 = Instantiate(Pool1[randomPool1], Shop1.transform.position, Quaternion.identity);
        Pool1.RemoveAt(randomPool1);
        GameObject Item2 = Instantiate(Pool2[randomPool2], Shop2.transform.position, Quaternion.identity);
        Pool2.RemoveAt(randomPool2);
    }
    void RemoveOption()
    {
        if (Shoptimer == true)
        {
            if (Item1 == null)
            {
                Destroy(Item2);
            }
            if (Item2 == null)
            {
                Destroy(Item1);
            }
        }
    }

}
