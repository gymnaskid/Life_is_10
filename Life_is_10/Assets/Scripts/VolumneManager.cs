
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumneManager : MonoBehaviour
{
    public VolumeController[] vcObjects;

    public float currentVolLevel;
    public float maxVolLevel = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        vcObjects = FindObjectsOfType<VolumeController>();

        if (currentVolLevel > maxVolLevel)
        {
            currentVolLevel = maxVolLevel;
        }

        for (int i = 0; i < vcObjects.Length; i++)
        {
            vcObjects[i].setAudioLevel(currentVolLevel);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
