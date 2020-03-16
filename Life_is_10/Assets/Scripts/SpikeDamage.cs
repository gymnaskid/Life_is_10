﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public GameObject returnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player Hit");
            other.transform.position = new Vector3(returnPoint.transform.position.x, returnPoint.transform.position.y, other.transform.position.z);
        }
    }
}
