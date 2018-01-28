using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Email : Internet {

    private Spawner spawner;
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
        textObj = GetComponentInChildren<Text>();

        type = InternetTypes.email;
        speed = spawner.emailSpeed;
    }

    private void SetSources()
    {

        int textNum = ChooseSource(spawner.emailTexts.Length);
        debug_text = spawner.emailTexts[textNum];
        textObj.text = debug_text;

    }

}
