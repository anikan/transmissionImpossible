using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Email : Internet {

    //When an email is created
    void Start()
    {
        type = InternetTypes.email;
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
