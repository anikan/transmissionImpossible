using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messaging : Internet {

    //When an instant message is created
    public override void Start()
    {
        base.Start();

        type = InternetTypes.messaging;

    }

}
