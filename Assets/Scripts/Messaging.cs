﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messaging : Internet {

    private Spawner spawner;
    private Text textObj;
    private AudioSource audioSrc;

    [SerializeField]
    private string debug_text;

    //When an instant message is created
    public override void Start()
    {
        base.Start();
        Setup();

        SetSources();

    }

    private void Setup()
    {
        spawner = GetComponentInParent<Spawner>();
        textObj = GetComponentInChildren<Text>();
        audioSrc = GetComponent<AudioSource>();

        type = InternetTypes.messaging;
        speed = spawner.messagingSpeed;
        audioSrc.clip = clip;
    }

    private void SetSources()
    {
        int textNum = ChooseSource(spawner.messagingTexts.Length);
        debug_text = spawner.messagingTexts[textNum];
        textObj.text = debug_text;
    }

}
