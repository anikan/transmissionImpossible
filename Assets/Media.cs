using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Media : Internet {

    public enum MediaTypes
    {
        image,
        video
    }

    //When media is created
    public override void Start()
    {
        base.Start();
        type = InternetTypes.media;
    }

}
