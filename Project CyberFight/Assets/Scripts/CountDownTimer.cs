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
            TimeToDisplay(ShopTime);
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
                active = true;
            }

    }
}
