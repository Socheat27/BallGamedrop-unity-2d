using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static BallControll;

public class InstanceEnemy : MonoBehaviour
{
    public  float nextSpawn = 10f; // Initial time to spawn the first enemy
    public Transform[] prefabToSpawn;
    public Sprite[] spritesItem;
    public float jitter = 0.25f;
    private float grade = 0;
    
    void Update()
    {
        // Check if it's time to spawn the next enemy
        if (Time.time > nextSpawn)
        {
            // Determine the type of enemy to spawn (0 or 1)
            int TypeEnem = Random.Range(0, 2);
            if (TypeEnem == 0)
            {

                var oo = Instantiate(prefabToSpawn[0], transform.position, Quaternion.identity);
                oo.GetComponent<SpriteRenderer>().sprite = spritesItem[0];
            }
            else
            {

                int spriteIndex = Random.Range(1, spritesItem.Length);
                var oo = Instantiate(prefabToSpawn[1], transform.position, Quaternion.identity);
                // Set the sprite for the enemy
                oo.GetComponent<SpriteRenderer>().sprite = spritesItem[spriteIndex];
                // Add or replace the BoxCollider2D component
                if (oo.GetComponent<BoxCollider2D>() == null)
                {
                    oo.AddComponent<BoxCollider2D>();
                }
                else
                {
                    Destroy(oo.GetComponent<BoxCollider2D>());
                    oo.AddComponent<BoxCollider2D>();
                }

            }
            if (ball > 100)
            {
                float T = Random.Range(0.5f, 2f);
                nextSpawn = Time.time + T;
            }
            else if (ball > 75)
            {
                float T = Random.Range(1f, 3f);
                nextSpawn = Time.time + T;
            }
            else if (ball > 50)
            {
                float T = Random.Range(2f, 4f);
                nextSpawn = Time.time + T;
            }
            else if (ball > 25)
            {
                float T = Random.Range(3f, 5f);
                nextSpawn = Time.time + T;
            }
            else if (ball > 10) 
            {
                float T = Random.Range(3f, 7f);
                nextSpawn = Time.time + T;
            }
            else
            {
                float T = Random.Range(5f, 10f);
                nextSpawn = Time.time + T;
            }
        }
    }
}
