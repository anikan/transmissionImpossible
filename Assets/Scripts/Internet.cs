using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internet : EnemySignal {

    
    protected enum InternetTypes
    {
        email,
        image,
        video,
        messaging
    }


    [Header("Properties")]
    [SerializeField]
    protected InternetTypes type;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected AudioClip clip;
    [SerializeField]
    protected bool isManualDestination;
    [SerializeField]
    protected Vector3 manualDirection;

    private Vector3 startPosition;
    private Vector3 destination;

    public virtual void Start()
    {
        if (isManualDestination)
        {
            destination = manualDirection;
        }
        else
        {
            //Update the location of the player
            destination = GetPlayerLocation();
        }

        //Get the current position of the enemy
        startPosition = transform.position;
    }

    //Travel across the screen in the direction set
    public void Travel()
    {
        destination = GetPlayerLocation();

        //Go toward the player!!!!!! 
        Vector3 direction = (destination - startPosition).normalized;

        //Change the position
        Vector3 currentPosition = transform.position;
        currentPosition.x += (direction.x * speed * Time.deltaTime);
        currentPosition.y += (direction.y * speed * Time.deltaTime);
        transform.position = currentPosition;

    }

    private Vector3 GetPlayerLocation()
    {
        return GameManager.instance.player.transform.position;
        //return Camera.main.transform.position;
    }

    public int ChooseSource(int size)
    {
        return Random.Range(0, size);
    }

    public void Update()
    {
        Travel();
    }



}
