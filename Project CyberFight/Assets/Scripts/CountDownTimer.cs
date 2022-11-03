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
}
