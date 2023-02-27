using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AssignTorch : MonoBehaviour
{
    public GameObject PlayerTorch;
    private bool PlayerIn;

    public GameObject objectToRemove;

    public AudioClip relicFound;
    private AudioSource source;

    public Door door;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIn)
        {
            PlayerTorch.GetComponentInChildren<Light2D>().enabled = true;
            door.HasKey = true;
            objectToRemove.SetActive(false);
            source.clip = relicFound;
            source.Play();
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
}
