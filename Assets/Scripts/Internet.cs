using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internet : Damage {

    
    protected enum InternetTypes
    {
        email,
        image,
        video,
        messaging
    }

    protected enum State
    {
        stopped,
        orienting,
        running,
        finished
    }


    [Header("Properties")]
    [SerializeField]
    protected InternetTypes type;
    [SerializeField]
    protected State state;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected AudioClip clip;
    [SerializeField]
    protected bool isManualDestination;
    [SerializeField]
    protected Vector3 manualDirection;
    [SerializeField]
    protected bool shouldOrient;

    private Vector3 startPosition;
    private Vector3 destination;

    public virtual void Start()
    {
        if (shouldOrient)
        {
            state = State.stopped;
            DecreaseColliderSize();
        } else
        {
            state = State.running;
        }

        SetDestination();

        //Get the current position of the enemy
        startPosition = transform.position;

    }

    private void DecreaseColliderSize()
    {
        BoxCollider2D coll = GetComponent<BoxCollider2D>();
        coll.size = new Vector2(coll.size.x / 2.0f, coll.size.y / 2.0f);
    }

    private void IncreaseColliderSize()
    {
        BoxCollider2D coll = GetComponent<BoxCollider2D>();
        coll.size = new Vector2(coll.size.x * 2.0f, coll.size.y * 2.0f);
    }

    private void SetDestination()
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
        return GameManager.instance.player.transform.position;
        //return Camera.main.transform.position;
    }

    public int ChooseSource(int size)
    {
        return Random.Range(0, size);
    }

    public void OrientSelf()
    {
        Debug.Log("OrientSelf");
        SetDestination();
        //transform.right = (destination - startPosition).normalized;
        StartCoroutine(OrientCoroutine());
        //state = State.running;
    }

    IEnumerator OrientCoroutine()
    {
        Quaternion startRotation = transform.rotation;
        transform.right = (destination - startPosition).normalized * 0.1f * Time.deltaTime;
        Quaternion endRotation = transform.rotation;
        transform.rotation = startRotation;

        float duration = 1.0f;

        for (float i = 0.0f; i < duration; i += Time.deltaTime)
        {
            Quaternion quat = Quaternion.Lerp(startRotation, endRotation, i / duration);
            transform.rotation = quat;
            yield return null;
        }
        state = State.running;
    }

    public bool CalculateBounds()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        Collider2D collide = GetComponent<Collider2D>();
        if (GeometryUtility.TestPlanesAABB(planes, collide.bounds))
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void Update()
    {
        if (state == State.stopped)
        {
            Travel();
            if (CalculateBounds())
            {
                IncreaseColliderSize();
                state = State.orienting;
                OrientSelf();
            }
        }
        else if (state == State.running)
        {
            Travel();
        }
    }



}
