using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public PlayerMove Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.moveX > 0 && !Player.facingRight)
        {
            Flipn();
        }
        if (Player.moveX < 0 && Player.facingRight)
        {
            Flipn();
        }
    }
     void Flipn()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        Debug.Log("Flip");
        Player.facingRight = !Player.facingRight;
    }
}
