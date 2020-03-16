using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YoungLimitController : MonoBehaviour
{

    public float youngTimer;
    private float timerCounter;
    public bool isYoung;

    public Slider slider;

    public GameObject youngView; //reference to the young view

    private ViewController VC;

    // Start is called before the first frame update
    void Start()
    {
        VC = FindObjectOfType<ViewController>();
        slider.maxValue = youngTimer;
        slider.value = youngTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //if we are young
        if (isYoung)
        {
           // Debug.Log("isyoung " + isYoung);
            timerCounter -= Time.deltaTime; //countdown

            //if the timer hits 0 swtich back to the old view
           // Debug.Log("Timer: " + timerCounter);
            if (timerCounter < 0f)
            {
               
                VC.SwitchView();
                isYoung = false; //set is young to false
            }
        }
        else if(!isYoung && timerCounter < youngTimer)
        {
            //slowly refil the time bar
            timerCounter += Time.deltaTime / 2;
        }

        slider.value = timerCounter;

        //if the young view is active set isyoung to true
        if (youngView.activeSelf)
        {
            isYoung = true;
        }
        else
        {
            isYoung = false;
        }
    }
}
