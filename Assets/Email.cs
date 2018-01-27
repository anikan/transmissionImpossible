using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Email : Internet {

    private Spawner spawner;
    private SpriteRenderer image;

    //When an email is created
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

        type = InternetTypes.email;
    }

    private void SetSources()
    {

        int imgNum = ChooseSource(spawner.emailIcons.Length);
        int textNum = ChooseSource(spawner.emailTexts.Length);

        Sprite img = spawner.emailIcons[imgNum];
        string text = spawner.emailTexts[textNum];

        image.sprite = img;
    }

}
