using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseMummy : MonoBehaviour
{
    private bool PlayerIn;
    public GameObject coffin;
    public GameObject aiObject;

    private bool released;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !released && PlayerIn)
        {
            coffin.GetComponent<Animator>().SetBool("Open",true);
            aiObject.SetActive(true);
            released = true;
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
