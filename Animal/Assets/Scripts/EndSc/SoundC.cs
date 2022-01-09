using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = (float)SoundA.volumes;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
