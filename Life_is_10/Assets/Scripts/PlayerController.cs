using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; //how fast can the player move
    public float jumpHeight; //How high we want to jump
    public bool canControl;

    private Rigidbody2D myBody; //the rigid body that will be used to move the player
    
    private Vector2 moveInput; //the direction the player is moving in
    private bool isMoving; //whether the player is moving or not
    private bool isJumping;
    private bool wallJump;
 

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
        {
            //only using x axis because you can only move left/right 
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            if (moveInput != Vector2.zero)
            {
                myBody.velocity = new Vector2(moveInput.x * moveSpeed, myBody.velocity.y);
            }
            else //if no left/right inputs stop the horizontal movement, but keep any vertical movement
            {
                myBody.velocity = new Vector2(0.0f, myBody.velocity.y);
                isMoving = false;
            }

            //if the player presses space, we want to jump
            if (!isJumping && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("btnX")))
            {
                if (wallJump)
                {
                    myBody.AddForce(Vector2.up * jumpHeight / 2, ForceMode2D.Impulse);
                }
                else
                {
                    myBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                }
                isJumping = true; //set is jumping to true as this may alter how the player can move or what they can do in the future
            }
        }
    }





    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor")
        {
            isJumping = false;
            wallJump = false;
        }
        if (other.gameObject.tag == "Wall")
        {
            isJumping = false;
            wallJump = true;
        }
    }
}
