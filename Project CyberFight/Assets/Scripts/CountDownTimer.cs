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
    public RapidFire Item1CS;
    public RapidFire Item2CS;
    public float WaveScaler;
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
        
        if(currentTime < 0)
        {
            active = false;
            Boss = true;
            currentTime = startingTime; //+ (Wave.Wave * WaveScaler);
        }
        if(Wave.Shop == true)
        {
            Shop = true;
        }
        if(Shoptimer == true)
        {
            ShopTime -= Time.deltaTime;
            RemoveOption();
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
            ShopTime = 15;
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
                Wave.Wave += 1;
                active = true;
            }

    }
    void SpawnShop()
    {
        int randomPool1 = Random.Range(0, Pool1.Count);
        int randomPool2 = Random.Range(0, Pool2.Count);
        Item1 = Instantiate(Pool1[randomPool1], Shop1.transform.position, Quaternion.identity);
        Item1CS = Item1.GetComponent<RapidFire>();
        Pool1.RemoveAt(randomPool1);
        Item2 = Instantiate(Pool2[randomPool2], Shop2.transform.position, Quaternion.identity);
        Item2CS = Item2.GetComponent<RapidFire>();
        Pool2.RemoveAt(randomPool2);
    }
    void RemoveOption()
    {
            if (Item1CS.PickedUp == true)
            {
                if(Item2 != null)
                {
                    Destroy(Item2);
                }
            }

            if (Item2CS.PickedUp == true)
            {
                if(Item1 != null)
                {
                    Destroy(Item1);
                }               
            }
        
            
    }

}
