using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeActivation : MonoBehaviour
{
    public GameObject ankh;
    private bool isActive;
    private SpriteRenderer[] initialSprites;
    public Sprite spikeOff;

    // Start is called before the first frame update
    void Start()
    {
        initialSprites = this.GetComponentsInChildren<SpriteRenderer>();
        foreach (var spriteRenderer in initialSprites)
        {
            spriteRenderer.sprite = spikeOff;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ankh.activeSelf && !isActive)
        {
            Animator[] animatorList = this.GetComponentsInChildren<Animator>();
            foreach(var animator in animatorList)
            {
                animator.enabled = true;
            }
            isActive = true;
        }
        
    }
}
