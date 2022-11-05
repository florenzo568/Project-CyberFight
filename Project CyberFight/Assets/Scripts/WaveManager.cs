using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int Wave = 0;
    //public Enemy Enemys;
    public CountDownTimer timer;
    private float time;
    public bool TimeUp;
    public bool Boss = false;
    public bool Shop = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = timer.currentTime;

        if (timer.Boss == true)
        {
            TimeUp = true;
        }
        if (TimeUp == true)
        {
            TimeUp = false;
            Wave += 1;
            timer.Boss = false;
            Boss = true;
           
        }
        if (Shop == true)
        {
            //Debug.Log("OpenShop");
        }

    }

    
}
