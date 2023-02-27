using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandpit : MonoBehaviour
{
    public PlayerMovement player;
    private AudioSource source;

    private bool playerIn;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (playerIn && !source.isPlaying)
        {
            source.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6 )
        {
            playerIn = true;
            player.speed = 0.5f;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6 )
        {
            playerIn = false;
            player.speed = 2;
        }
    }
    
        
}
