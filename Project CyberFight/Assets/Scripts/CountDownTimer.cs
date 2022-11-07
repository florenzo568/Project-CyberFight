using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public float currentTime;
    public float startingTime;
    public bool Boss = false;
    public bool active = true;
    public TextMeshProUGUI textmeshPro;
    float minutes;
    float seconds;

    void Start()
    {
        currentTime = startingTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
        currentTime -= 1 * Time.deltaTime;
        }
        TimeToDisplay(currentTime);
        if(currentTime <= 0)
        {
            active = false;
            Boss = true;
            currentTime = startingTime;
        }
    }
    void TimeToDisplay(float time)
    {
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        textmeshPro.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
<<<<<<< Updated upstream
=======

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
            ShopTime = 30;
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

>>>>>>> Stashed changes
}
