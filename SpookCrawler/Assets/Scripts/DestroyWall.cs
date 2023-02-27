using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7 )
        {
            anim.SetBool("Open",true);
            GetComponent<AudioSource>().Play();
        }
    }
}
