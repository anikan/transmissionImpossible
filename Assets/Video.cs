using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : Media {

    [SerializeField]
    private MediaTypes mediaType;

    [SerializeField]
    private Sprite image;

    [SerializeField]
    private AudioClip sound;


    public override void Start()
    {
        base.Start();
        mediaType = MediaTypes.video;
    }

}
