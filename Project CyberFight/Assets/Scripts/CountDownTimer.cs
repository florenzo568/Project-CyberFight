using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public float currentTime;
    public float startingTime;
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
        currentTime -= 1 * Time.deltaTime;
        TimeToDisplay(currentTime);
        if(currentTime <= 0)
        {
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
