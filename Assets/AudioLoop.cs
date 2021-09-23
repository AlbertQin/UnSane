using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceLoop : MonoBehaviour
{
    AudioSource m_AudioSource;

    void Start()
    {
        //Fetch the AudioSource component of the GameObject (make sure there is one in the Inspector)
        m_AudioSource = GetComponent<AudioSource>();
        //Stop the Audio playing
        m_AudioSource.Play();
        m_AudioSource.loop = true;
    }

    void Update()
    {

    }
}
