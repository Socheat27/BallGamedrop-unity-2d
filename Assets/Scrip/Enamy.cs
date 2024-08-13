using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BallControll;

public class Enamy : MonoBehaviour
{
    private float speed=3;

    void Update()
    {
        if (ball > 100)
            speed = 9;
        else if (ball > 80)
            speed = 8;
        else if (ball>60)     
            speed = 7;      
        else if(ball >40)
            speed = 6;
        else if (ball > 20)
            speed = 5;
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
    
}
