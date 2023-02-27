using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoulderMovement : MonoBehaviour
{
    private float initialVelocity = .5f;
    private float acceleration = 0.1f;
    private float topSpeed = 6.0f;

    private Rigidbody2D rb;
    public bool isActivated = false;
    public bool isMoving = false;

    private int Respawn;

    public AudioClip fall;
    public AudioClip roll;

    private AudioSource source;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();

        source.clip = fall;
        source.Play();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (isActivated && isMoving && initialVelocity < topSpeed)
        {
            initialVelocity += acceleration;
            rb.velocity = new Vector2(initialVelocity, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 6 )
        {
            col.gameObject.GetComponent<PlayerMovement>().death = true;
        }

        if (col.gameObject.layer == 8)
        {
            rb.velocity = new Vector2(initialVelocity, 0f);
            isMoving = true;
            
            source.Stop();
            source.clip = roll;
            source.loop = false;
            source.Play();
        }
    }

    public void Activate()
    {
        isActivated = true;
    }
}
