using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Music;
public class shepDeffance : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.CompareTag("Enemy"))
        {
            music.Musics[2].Play();
            Destroy(other.gameObject); // Destroy the GameObject that triggered the collision
        }
    }
}
