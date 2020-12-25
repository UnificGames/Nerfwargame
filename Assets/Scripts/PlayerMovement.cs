using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables
    public float movementSpeed;
    public Rigidbody2D rb;

    public Animator anim;

    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;

    float mx;

    private void Update(){
        mx = Input.GetAxisRaw("Horizontal");
        //jump controls
        if (Input.GetButtonDown("Jump") && isGrounded()){
            Jump();
        }
        //horizonal movement controls
        if (Mathf.Abs(mx) > 0.05f){
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }

        //facing correct direction
        if(mx >0f){
            transform.localScale = new Vector2(1f, 1f);            
        } else if (mx < 0f){
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

    private void FixedUpdate(){
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
    //Jumping force and ability
    void Jump(){
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
    }
    //Check for the ground
    public bool isGrounded(){
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck.gameObject != null) {
            return true;
        }
        return false;
    }
}
