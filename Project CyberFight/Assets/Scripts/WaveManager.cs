using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int Wave = 0;
    public Enemy Enemys;
    public CountDownTimer timer;
    private float time;
    public bool TimeUp;

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
            Debug.Log("Wave Over: Open Shop" + Wave);
            timer.Boss = false;
            timer.active = true;
           
        }

    }

    
}
