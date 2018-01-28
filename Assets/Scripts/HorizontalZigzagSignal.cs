using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalZigzagSignal : MonoBehaviour {

    public float maxXDelta =2.0f;

    private float initXPos;

    public float ySpeed = .1f;
    public float xSpeed = .1f;

    public bool startGoingLeft = true;

	// Use this for initialization
	void Start () {
        initXPos = transform.localPosition.x;

        StartCoroutine(EnemyMovement());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y + ySpeed * Time.deltaTime, transform.position.z);
	}

    IEnumerator EnemyMovement()
    {
        float currentXDelta = 0.0f;

        if (startGoingLeft)
        {
            currentXDelta = maxXDelta;
        }

        else
        {
            currentXDelta = -maxXDelta;
        }

        while (true)
        {
            //Move left.
            for (; currentXDelta > -maxXDelta;  currentXDelta -= xSpeed * Time.deltaTime)
            {
                transform.position = new Vector3(initXPos + currentXDelta, transform.position.y, transform.position.z);
                yield return null;
            }

            //Move right.
            for (; currentXDelta < maxXDelta; currentXDelta += xSpeed * Time.deltaTime)
            {
                transform.position = new Vector3(initXPos + currentXDelta, transform.position.y, transform.position.z);
                yield return null;
            }
        }
    }
}
