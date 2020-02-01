using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed; 
    public float jumpForce;  
    public bool isJumping;
    public float speed;

    public BoxCollider2D col;
    const float ySize = 10f;
    const float newOffset = 1.4f;

    public int curRepair;
    public int maxRepair = 3;
    bool repair;
    bool damaged;
    public int repairValue = 1;
    public int damageValue = 1;

    public Rigidbody2D rb;

    private void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        curRepair = 0;
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
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            col.size = new Vector2(col.size.x, ySize);
            col.offset = new Vector2(col.offset.x, newOffset);

            Repair(repairValue);           
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage(damageValue);
        }
    }

    public void Repair(int rpr)
    {
        curRepair += rpr;
        repair = true;
    }

    public void Damage(int dmg)
    {
        curRepair -= dmg;
        damaged = true;
    }


}
    
