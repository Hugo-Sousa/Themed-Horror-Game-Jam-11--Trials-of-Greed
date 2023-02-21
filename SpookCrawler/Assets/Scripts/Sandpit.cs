using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandpit : MonoBehaviour
{
    public PlayerMovement player;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 6 )
            {
                player.speed = 0.5f;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == 6 )
            {
                player.speed = 2;
            }
        }
    
        
}
