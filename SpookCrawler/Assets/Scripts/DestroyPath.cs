using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestroyPath : MonoBehaviour
{
    public PlateBehaviour plate;

    public GameObject path;
    // Update is called once per frame
    void Update()
    {
        if (plate.isActivated)
        {
            Destroy(path);
        }
    }
}
