using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MummySounds : MonoBehaviour
{
    public AudioClip[] grunts;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (!source.isPlaying)
        {
            int index = Random.Range(0, 3);

            source.clip = grunts[index];
            source.Play();
        }
    }
}
