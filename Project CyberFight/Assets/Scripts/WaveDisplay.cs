using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveDisplay : MonoBehaviour
{
    public TextMeshProUGUI Waves;
    public WaveManager WaveScript;
    public CountDownTimer CountDown;
    public int Wave = 0;
    public bool Boss;
    void Start()
    {
        Wave = WaveScript.Wave;
        Waves.text = Wave.ToString();
    }

    // Update is called once per frame
    void Update()
    {

            Wave = WaveScript.Wave;
            Waves.text = Wave.ToString();

        
    }
}
