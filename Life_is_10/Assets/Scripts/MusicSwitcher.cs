using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    private MusicController MC;

    public int newTrack;
    public bool switchOnStart;

    // Start is called before the first frame update
    void Start()
    {
        MC = FindObjectOfType<MusicController>();

        if (switchOnStart)
        {
            MC.switchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            MC.switchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }
}
