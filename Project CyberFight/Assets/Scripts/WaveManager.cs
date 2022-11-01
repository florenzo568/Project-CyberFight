using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int Wave = 1;
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
        StartCoroutine(Wave1());
        if (time <= .5)
        {
            TimeUp = true;
        }

    }

    IEnumerator Wave1()
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Boss Spawn");

    }
}
