using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messaging : Internet {

    //When an instant message is created
    void Start()
    {
        type = InternetTypes.messaging;
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
