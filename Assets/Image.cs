using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image : Media {

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

        type = InternetTypes.image;
    }

    private void SetSources()
    {

        int imgNum = ChooseSource(spawner.mediaImages.Length);

        Sprite img = spawner.mediaImages[imgNum];

        image.sprite = img;
    }


}
