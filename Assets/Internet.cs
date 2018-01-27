using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internet : MonoBehaviour {

    
    protected enum InternetTypes
    {
        email,
        media,
        messaging
    }


    [Header("Properties")]
    [SerializeField]
    protected InternetTypes type;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private Vector3 startPosition;

    //Travel across the screen in the direction set
    public virtual void Travel()
    {

    }

    //Destroy itself once it goes outside the camera bounds
    public virtual void Destroy()
    {

    }

}
