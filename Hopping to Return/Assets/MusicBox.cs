using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
  AudioSource[] tracks;
    // Start is called before the first frame update
    void Start()
    {
    tracks = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
