using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSwitch : MonoBehaviour
{
    private ViewController VC;
        // Start is called before the first frame update
        void Start()
        {
        VC = FindObjectOfType<ViewController>();
        }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            VC.SwitchView();
            //gameObject.SetActive(false);
        }
    }
}
