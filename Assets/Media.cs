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
    void Start()
    {
        type = InternetTypes.media;
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
