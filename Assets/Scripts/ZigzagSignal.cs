using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigzagSignal : MonoBehaviour {

    public float maxDelta =2.0f;
    public float initDelta = 0.0f;

    private Vector2 initPos;

    public float ySpeed = .1f;
    public float xSpeed = .1f;

    public bool horizontalMovement = false;
    public bool verticalMovement = false;

	// Use this for initialization
	void Start () {
        initPos = transform.localPosition;

        if (horizontalMovement)
        {
            StartCoroutine(HorizontalZigzag());
        }

        if (verticalMovement)
        {
            StartCoroutine(VerticalZigzag());
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (!verticalMovement)
        {
            transform.Translate(0, ySpeed * Time.deltaTime, 0);
        }

        if (!horizontalMovement)
        {
            transform.Translate(xSpeed * Time.deltaTime, 0, 0);
        }
    }

    IEnumerator HorizontalZigzag()
    {
        float currentXDelta = 0.0f;

        while (true)
        {
            //Move left.
            for (; currentXDelta > -maxDelta;  currentXDelta -= xSpeed * Time.deltaTime)
            {
                transform.localPosition = new Vector3(initPos.x + currentXDelta, transform.localPosition.y, transform.localPosition.z);

                yield return null;
            }

            //Move right.
            for (; currentXDelta < maxDelta; currentXDelta += xSpeed * Time.deltaTime)
            {
                transform.localPosition = new Vector3(initPos.x + currentXDelta, transform.localPosition.y, transform.localPosition.z);
                yield return null;
            }
        }
    }

    IEnumerator VerticalZigzag()
    {
        float currentYDelta = 0.0f;

        while (true)
        {
            //Move left.
            for (; currentYDelta > -maxDelta; currentYDelta -= xSpeed * Time.deltaTime)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, initPos.y + currentYDelta, transform.localPosition.z);
                yield return null;
            }

            //Move right.
            for (; currentYDelta < maxDelta; currentYDelta += xSpeed * Time.deltaTime)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, initPos.y + currentYDelta, transform.localPosition.z);
                yield return null;
            }
        }
    }
}
