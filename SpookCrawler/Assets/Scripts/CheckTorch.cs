using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CheckTorch : MonoBehaviour
{
    public GameObject torch;
    public PlayerMovement player;
    private bool checkedTorch;

    void Update()
    {
        if (!checkedTorch && torch.GetComponentInChildren<Light2D>().enabled)
        {
            player.anim.SetBool("Torch", true);
            checkedTorch = true;
        }
    }
}
