using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : Internet {

    private Spawner spawner;
    private SpriteRenderer image;

    public override void Start()
    {
        base.Start();
        Setup();

        SetSources();

    }

    private void Setup()
    {
        spawner = GetComponentInParent<Spawner>();
        image = GetComponent<SpriteRenderer>();

        type = InternetTypes.video;
    }

    private void SetSources()
    {

        int imgNum = ChooseSource(spawner.mediaVideos.Length);

        Sprite img = spawner.mediaVideos[imgNum];

        image.sprite = img;
    }

}
