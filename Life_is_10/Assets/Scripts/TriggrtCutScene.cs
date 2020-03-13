using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggrtCutScene : MonoBehaviour
{
    private SimpleCutScene CS;

    public Animator anim;
    public float cutSceneTime;

    void Start()
    {
        CS = FindObjectOfType<SimpleCutScene>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            CS.playCutScene(anim, cutSceneTime);
        }
    }
}
