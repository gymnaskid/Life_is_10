using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCutScene : MonoBehaviour
{
    private PlayerController PC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playCutScene(Animator anim, float cutSceneTime)
    {
        PC = FindObjectOfType<PlayerController>();
        StartCoroutine(PlayScene(anim, cutSceneTime));
    }

    IEnumerator PlayScene(Animator anim, float cutSceneTime)
    {
        //Stop letting teh player get input
        PC.canControl = false;
        PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        anim.SetTrigger("Play"); //play the scene

        yield return new WaitForSeconds(cutSceneTime);

        //give back control after scene
        PC.canControl = true;
        Destroy(gameObject);

    }
}
