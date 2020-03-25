using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static bool musicExists;

    public AudioSource[] musicTracks;
    public int currentTrack;
    public bool playMusic;
    // Start is called before the first frame update
    void Start()
    {
        if (!musicExists)
        {
            musicExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playMusic)
        {
            if (!musicTracks[currentTrack].isPlaying)
            {
                musicTracks[currentTrack].Play();
            }
        }
        else
        {
            musicTracks[currentTrack].Stop();
        }
    }

    public void switchTrack(int newTrack)
    {
        if (newTrack != currentTrack)
        {
            musicTracks[currentTrack].Stop();
            currentTrack = newTrack;
        }

    }
}
