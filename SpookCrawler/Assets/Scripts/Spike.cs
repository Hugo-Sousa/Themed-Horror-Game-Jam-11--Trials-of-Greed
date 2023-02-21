using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public PlayerMovement player;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6 )
        {
            player.death = true;
        }
    }
}
