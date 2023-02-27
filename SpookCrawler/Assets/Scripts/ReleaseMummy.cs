using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseMummy : MonoBehaviour
{
    private bool PlayerIn;
    public GameObject coffin;
    public GameObject aiObject;

    private bool released;
    private PlayerMovement player;

    public AudioClip openCoffin;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !released && PlayerIn)
        {
            coffin.GetComponent<Animator>().SetBool("Open",true);
            aiObject.SetActive(true);
            released = true;
            player.chase = true;
            GetComponent<AudioSource>().clip = openCoffin;
            GetComponent<AudioSource>().Play();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6 )
        {
            PlayerIn = true;
            player = other.gameObject.GetComponent<PlayerMovement>();
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
