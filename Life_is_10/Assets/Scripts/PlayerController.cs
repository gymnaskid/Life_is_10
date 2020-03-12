using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; //how fast can the player move

    private Rigidbody2D myBody; //the rigid body that will be used to move the player

    private Vector2 moveInput; //the direction the player is moving in
    private bool isMoving; //whether the player is moving or not

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //only using x axis because you can only move left/right 
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized;
        if(moveInput != Vector2.zero)
        {
            myBody.velocity = new Vector2(moveInput.x * moveSpeed, 0f);
            isMoving = true;
        }
        else
        {
            myBody.velocity = Vector2.zero;
            isMoving = false;
        }
    }
}
