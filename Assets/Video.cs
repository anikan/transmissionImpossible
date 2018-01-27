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


    void Start()
    {
        mediaType = MediaTypes.video;
    }

    //Travel across the screen in the direction set
    public override void Travel()
    {

    }

    //Destroy itself once it goes outside the camera bounds
    public override void Destroy()
    {

    }
}
