using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image HealthBari;
    public float CurrentHealth;
    public float MaxHealth;
    public PlayerMove Player;
    void Start()
    {
        MaxHealth = Player.Health;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Player.Health;
        HealthBari.fillAmount = CurrentHealth / MaxHealth;
    }
}
