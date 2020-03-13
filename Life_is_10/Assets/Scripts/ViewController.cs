using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public GameObject youngView; //reference to the young view
    public GameObject oldView;//refence to the old view

    public bool isOldView; //wheter we are currently looking at the old view

    // Start is called before the first frame update
    void Start()
    {
        //when starting the level find out which one should be shown and hide the other one
        if(isOldView)
        {
            youngView.SetActive(false);
        }
        else
        {
            oldView.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(isOldView)
            {
                //turn on the young view
                youngView.SetActive(true);
                //turn off the old view
                oldView.SetActive(false);
                isOldView = false;
            }
            else
            {
                //turn on old view
                oldView.SetActive(true);
                //turn off youngview
                youngView.SetActive(false);
                isOldView = true;
            }

        }
    }
}
