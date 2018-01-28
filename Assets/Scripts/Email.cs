using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Email : Internet {

    private Spawner spawner;
    private SpriteRenderer image;
    private Text textObj;

    [SerializeField]
    private string debug_text;

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
        textObj = GetComponentInChildren<Text>();

        type = InternetTypes.email;
    }

    private void SetSources()
    {

        int imgNum = ChooseSource(spawner.emailIcons.Length);
        int textNum = ChooseSource(spawner.emailTexts.Length);

        Sprite img = spawner.emailIcons[imgNum];
        debug_text = spawner.emailTexts[textNum];

        image.sprite = img;
        textObj.text = debug_text;

    }

}
