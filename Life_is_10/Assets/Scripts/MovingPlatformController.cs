using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public bool isVertical;
    public bool isHorizontal;

    public float moveSpeed;

    //private BoxCollider2D myBox;
    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
      //  myBox = GetComponent<BoxCollider2D>();
        myBody = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if(isVertical)
        {
            //the platform is goin to move up/down
            myBody.velocity = new Vector2( 0.0f, moveSpeed);
        }
        
        if(isHorizontal)
        {
            //the platform is going to move left/right
            myBody.velocity = new Vector2( moveSpeed, 0.0f);
        }
    }


    public void TurnAround()
    {
        moveSpeed = -moveSpeed;
    }
}
