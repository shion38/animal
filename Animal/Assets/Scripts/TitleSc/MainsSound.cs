﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainsSound : MonoBehaviour
{
    public double volumes = 0.05;
    public GameObject Audio;
    // Start is called before the first frame update
    void Start()
    {
        //アタッチされているAudioSource取得
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = Audio.GetComponent<ChangeAudio>().nowVo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
