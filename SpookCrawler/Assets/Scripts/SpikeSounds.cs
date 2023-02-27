using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSounds : MonoBehaviour
{
    public AudioSource on;
    public AudioSource off;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(anim.gameObject.activeSelf);
        
        if (on.enabled && !on.isPlaying && anim.enabled)
        {
            on.Play();
        } 
        if (off.enabled && !off.isPlaying && anim.enabled)
        {
            off.Play();
        } 
    }
}
