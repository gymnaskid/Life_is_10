using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; //how fast can the player move
    public float jumpHeight; //How high we want to jump
    public bool canControl;
    public bool canWallJump; //can the player wall jump
    public bool isJumping; //needs to be public so it can be set when changinf views

    private Rigidbody2D myBody; //the rigid body that will be used to move the player
    private Animator anim;

    private Vector2 moveInput; //the direction the player is moving in
    private Vector2 lastMove; //whether the player is moving or not
    private bool isMoving;
    
    private bool wallJump;
    private float PlatformSpeed;
    private float speed;
    private bool onPlatform;

 

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lastMove = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
        {
            //only using x axis because you can only move left/right 
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
           
            speed = PlatformSpeed + (moveInput.x * moveSpeed);

            if (moveInput != Vector2.zero)
            {
                isMoving = true;
                lastMove = moveInput;
                myBody.velocity = new Vector2(speed, myBody.velocity.y);
            }
            else if(onPlatform)
            {
                myBody.velocity = new Vector2(speed, myBody.velocity.y);
                isMoving = false;
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

            //set vars for animations
            anim.SetFloat("lastMove", lastMove.x);
            anim.SetBool("isMoving", isMoving);

        }
    }





    void OnCollisionEnter2D(Collision2D other)
    {
        
        string otherTag = other.gameObject.tag;
        if (otherTag == "Floor" || otherTag == "MovingPlatform")
        {
            //if we touch the ground make sure we can jump agian
            isJumping = false;
            wallJump = false;
        }
        if (canWallJump && otherTag == "Wall")
        {
            //if we touch a wall allow for a wall jumo
            isJumping = false;
            wallJump = true;
        }
       
    }

    void OnCollisionStay2D(Collision2D other)
    {
        string otherTag = other.gameObject.tag;
        if (otherTag == "MovingPlatform" && other.gameObject.GetComponent<MovingPlatformController>().isHorizontal)
        {
            //if we are on a platform that moves left/right move with it
            PlatformSpeed = other.gameObject.GetComponent<MovingPlatformController>().moveSpeed;
            onPlatform = true;
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        //when we are no longer on the platform stop adding its movement to ours
        string otherTag = other.gameObject.tag;
        if (otherTag == "MovingPlatform")
        {
            PlatformSpeed = 0;
            onPlatform = false;
        }
    }
}
