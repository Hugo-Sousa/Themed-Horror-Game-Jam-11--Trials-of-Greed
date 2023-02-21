using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveArea : MonoBehaviour
{
    public bool isForward;
    private bool PlayerIn;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIn)
        {
            if (isForward)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}
