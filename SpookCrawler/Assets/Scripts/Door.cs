using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private Animator anim;

    private bool IsOpen;
    public bool HasKey;

    private bool PlayerIn;

    public AudioClip open;
    private AudioSource source;
    
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        source = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (HasKey && !IsOpen && PlayerIn)
            {
                anim.SetBool("Open",true);
                IsOpen = true;
                source.clip = open;
                source.Play();
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
