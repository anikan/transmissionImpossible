using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messaging : Internet {

    private Spawner spawner;
    private SpriteRenderer image;

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
        image = GetComponent<SpriteRenderer>();

        type = InternetTypes.messaging;
    }

    private void SetSources()
    {

        int imgNum = ChooseSource(spawner.messagingIcons.Length);
        int textNum = ChooseSource(spawner.messagingTexts.Length);

        Sprite img = spawner.messagingIcons[imgNum];
        string text = spawner.messagingTexts[textNum];

        image.sprite = img;
    }

}
