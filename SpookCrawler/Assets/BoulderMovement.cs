using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoulderMovement : MonoBehaviour
{
    private float initialVelocity = 3.0f;
    private float acceleration = 0.1f;
    private float topSpeed = 6.0f;

    private Rigidbody2D rb;
    private bool isActivated = false;
    private bool isMoving = false;

    private int Respawn;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isActivated)
        {
            rb.velocity = new Vector2(initialVelocity, 0f);
            isMoving = true;
        }
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
        if(col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(Respawn);
        }
    }

    public void Activate()
    {
        isActivated = true;
    }
}
