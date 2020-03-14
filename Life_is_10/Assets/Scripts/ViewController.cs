using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ViewController : MonoBehaviour
{
    public GameObject youngView; //reference to the young view
    public GameObject oldView;//refence to the old view

    public GameObject youngPlayer;
    public GameObject oldPlayer;

    public bool canSwitch;

    public CinemachineVirtualCamera cam;

    public bool isOldView; //wheter we are currently looking at the old view


    

    // Start is called before the first frame update
    void Start()
    {
        //when starting the level find out which one should be shown and hide the other one
        if(isOldView)
        {
            youngView.SetActive(false);
            youngPlayer.SetActive(false);
            cam.Follow = oldPlayer.transform; //make sure camera is following teh right player
        }
        else
        {
            oldView.SetActive(false);
            oldPlayer.SetActive(false);
            cam.Follow = youngPlayer.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if the player can switch between views loof for the input to do so
        if(canSwitch)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("btnSqu"))
            {
                SwitchView();
            }
        }   
    }

    public void SwitchView()
    {
        if (isOldView)
        {
          
            youngView.SetActive(true);
            youngPlayer.SetActive(true);

            //Set the young player to where the old player is
            youngPlayer.transform.position = new Vector3(oldPlayer.transform.position.x, oldPlayer.transform.position.y, youngPlayer.transform.position.z);
            youngPlayer.GetComponent<Rigidbody2D>().velocity = oldPlayer.GetComponent<Rigidbody2D>().velocity;
            youngPlayer.GetComponent<PlayerController>().isJumping = oldPlayer.GetComponent<PlayerController>().isJumping;
            
            //turn off the old view and old player
            oldView.SetActive(false);
            oldPlayer.SetActive(false);
            cam.Follow = youngPlayer.transform;

            isOldView = false;
        }
        else
        {
            //turn on old view
            oldView.SetActive(true);
            oldPlayer.SetActive(true);

            oldPlayer.transform.position = new Vector3(youngPlayer.transform.position.x, youngPlayer.transform.position.y, oldPlayer.transform.position.z);
            oldPlayer.GetComponent<Rigidbody2D>().velocity = youngPlayer.GetComponent<Rigidbody2D>().velocity;
            oldPlayer.GetComponent<PlayerController>().isJumping = youngPlayer.GetComponent<PlayerController>().isJumping;
           
            //turn off youngview
            youngView.SetActive(false);
            youngPlayer.SetActive(false);
            cam.Follow = oldPlayer.transform;

            isOldView = true;
        }
    }

    private void SetSwitch(GameObject Use, GameObject Set)
    {
        Set.transform.position = new Vector3(Use.transform.position.x, Use.transform.position.y, Use.transform.position.z);
        Set.GetComponent<Rigidbody2D>().velocity = Set.GetComponent<Rigidbody2D>().velocity;
        Set.GetComponent<PlayerController>().isJumping = Use.GetComponent<PlayerController>().isJumping;     
    }
}
