using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed; 
    public float jumpForce;  
    public bool isJumping;
    public float speed;
     
    public Rigidbody2D rb;

    private void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void FixedUpdate()
    {   
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {          
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            isJumping = true;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            
            rb.velocity = Vector2.zero;
        }
    }   
}
    
