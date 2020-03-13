using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLimit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if there is a collision and the other object is a moving platform
    //tell it to turn around
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MovingPlatform")
        {
            other.GetComponent<MovingPlatformController>().TurnAround();
        }
    }
}
