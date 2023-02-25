using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed;
    public Rigidbody2D rb;
    private Vector2 movement;
    
    public Animator anim;

    public bool death;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (death)
        {
            anim.SetBool("Death", true);
        }
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
    }
    
    private void FixedUpdate()
    {
        Controller();
    }
    
    private void Controller()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void ChangeScale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, 1);
    }
}
