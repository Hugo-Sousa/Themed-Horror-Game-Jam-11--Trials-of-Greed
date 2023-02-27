using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip background;
    public AudioClip chase;
    public AudioClip death;

    public AudioSource source;
    private PlayerMovement player;

    private bool isPlaying;
    private bool changeChase;
    private bool isDead;
    
    void Start()
    {
        player = GetComponent<PlayerMovement>();
        changeChase = player.chase;
    }
    
    void Update()
    {

        if (player.chase != changeChase && !player.chase)
        {
            changeClip(background,true);
        }

        if (player.chase != changeChase && player.chase)
        {
            changeClip(chase, true);
        }

        if (player.anim.GetBool("Death") && !isDead)
        {
            isDead = true;
            changeClip(death, false);
        }
    }

    void changeClip(AudioClip clip, bool toLoop)
    {
        if (isPlaying)
        {
            source.Stop();
        }
            
        source.clip = clip;
        source.loop = toLoop;
        source.Play();
        
        changeChase = player.chase;
    }
}
