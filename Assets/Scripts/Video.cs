using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : Internet {

    private Spawner spawner;

    public override void Start()
    {
        base.Start();
        Setup();

    }

    private void Setup()
    {
        spawner = GetComponentInParent<Spawner>();

        type = InternetTypes.video;
        speed = spawner.videoSpeed;
    }


}
