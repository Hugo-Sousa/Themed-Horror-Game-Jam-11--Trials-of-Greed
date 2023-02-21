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

    public Door door;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIn)
        {
            PlayerTorch.GetComponentInChildren<Light2D>().enabled = true;
            door.HasKey = true;
            objectToRemove.SetActive(false);
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
