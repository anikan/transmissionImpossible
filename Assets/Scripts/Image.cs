using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image : Internet {

    private Spawner spawner;
    private AudioSource audioSrc;

    public override void Start()
    {
        base.Start();
        Setup();

    }

    private void Setup()
    {
        spawner = GetComponentInParent<Spawner>();
        audioSrc = GetComponent<AudioSource>();

        type = InternetTypes.image;
        speed = spawner.imageSpeed;
        audioSrc.clip = clip;
    }


}
