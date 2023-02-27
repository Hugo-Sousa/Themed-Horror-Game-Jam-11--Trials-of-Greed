using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed;
    public Rigidbody2D rb;
    private Vector2 movement;
    
    public Animator anim;

    public bool death;
    private bool died;
    public bool chase;

    void Update()
    {
        if (death && !died)
        {
            died = true;
            anim.SetBool("Death", true);
            StartCoroutine(Death());
        }
        else
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
        }
    }
    
    private void FixedUpdate()
    {
        if (!death)
        {
            Controller();   
        }
    }
    
    private void Controller() {

        movement.Normalize();
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
       
    }

    public void ChangeScale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, 1);
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
