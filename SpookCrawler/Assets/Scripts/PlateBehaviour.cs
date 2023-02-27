using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehaviour : MonoBehaviour
{
    public GameObject boulderPrefab;

    private Animator anim;
    
    public bool isActivated;
    public bool isInverted;

    public Transform spawnBoulder;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.name == "Player" && !isActivated)
        {
            source.Play();
            isActivated = true;
            GetComponent<Collider2D>().enabled = false;
            anim.SetBool("Pressed",true);
            GameObject boulder = Instantiate(boulderPrefab, spawnBoulder.position, boulderPrefab.transform.rotation);

            if (isInverted)
            {
                boulder.GetComponent<Rigidbody2D>().gravityScale = -1;
            }
            
            boulder.GetComponent<BoulderMovement>().Activate();
        }       
    }
    
}
