using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;

    private bool IsOpen;
    public bool HasKey;

    private bool PlayerIn;
    
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (HasKey && !IsOpen && PlayerIn)
            {
                anim.SetBool("Open",true);
                IsOpen = true;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6 )
        {
            PlayerIn = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6 )
        {
            PlayerIn = false;
        }
    }

    bool AnimatorIsPlaying(){
        return anim.GetCurrentAnimatorStateInfo(0).length >
               anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    
    
}
