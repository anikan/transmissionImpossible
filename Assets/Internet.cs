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
    protected float speed;

    private Vector3 startPosition;
    private Vector3 destination;

    public virtual void Start()
    {
        //Update the location of the player
        destination = GetPlayerLocation();

        //Get the current position of the enemy
        startPosition = transform.position;
    }

    //Travel across the screen in the direction set
    public void Travel()
    {

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
        return Camera.main.transform.position;
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
