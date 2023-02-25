using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoulderPath : MonoBehaviour
{
    public PlateBehaviour plate;
    private Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        col.enabled = plate.isActivated;
    }
}
