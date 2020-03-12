using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private LevelLoader LL;
    // Start is called before the first frame update
    void Start()
    {
        LL = FindObjectOfType<LevelLoader>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            LL.LoadNextLevel();
        }
        else
        {
            Debug.Log("other");
        }
    }
}
