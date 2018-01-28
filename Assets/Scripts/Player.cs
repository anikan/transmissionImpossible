﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float playerSpeed = 5.0f;
    public float minDistance = .5f;

    public float maxHealth = 5.0f;
    private float health;

    public float timeBetweenPulses = .1f;

    //Player trail variables
    public float maxWidth = 1.0f;
    public float minWidth = .1f;

    public float maxChangePerSecond = 5.0f;
    private float changePerSecond;

    public float maxStaticWhileAlive = .5f;

    public float maxScreenShakeAmount = .2f;

    public Material staticPlaneMat;

	// Use this for initialization
	void Start () {

        health = maxHealth;
        changePerSecond = maxChangePerSecond;

        StartCoroutine(UpdateTrails());

        //Set static to be completely transparent.
        Color color = staticPlaneMat.GetColor("_Color");

        color.a = 0;

        staticPlaneMat.SetColor("_Color", color);
    }
	
	// Update is called once per frame
	void Update () {

        //Process touch
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary))
        {
            Vector2 touchPosition = Input.GetTouch(0).position;

            Vector3 viewportPoint = Camera.main.ScreenToWorldPoint(touchPosition);

            HandlePositionChange(viewportPoint);
        }

        //Process mouse click.
        else if (Input.GetMouseButton(0))
        {
            Vector3 viewportPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 clickPosition = new Vector2(viewportPoint.x, viewportPoint.y);

            HandlePositionChange(clickPosition);
        }

        else
        {
           // GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }
    }

    //Given a target position, calculate the velocity needed to approach it.
    void HandlePositionChange(Vector2 targetPosition)
    {
        Vector2 distanceToTarget = targetPosition - new Vector2(transform.localPosition.x, transform.localPosition.y);

        if (distanceToTarget.magnitude > minDistance)
        {
            Vector2 velocityToTarget = distanceToTarget.normalized * playerSpeed;

            GetComponent<Rigidbody2D>().velocity = velocityToTarget;
        }

        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    IEnumerator UpdateTrails()
    {
        print(changePerSecond);

        while (health > 0)
        {
            //Shrink
            while (GetComponent<TrailRenderer>().widthMultiplier > minWidth)
            {

                GetComponent<TrailRenderer>().widthMultiplier -= changePerSecond * Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(timeBetweenPulses);

            //Grow
            while (GetComponent<TrailRenderer>().widthMultiplier < maxWidth)
            {
                GetComponent<TrailRenderer>().widthMultiplier += changePerSecond * Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(timeBetweenPulses);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemySignal enemy = collision.collider.GetComponent<EnemySignal>();

        if (enemy)
        {
            health -= enemy.damageValue;
            //Play some damage effects!
            //Slow down the pulsing.
            changePerSecond = (health / maxHealth) * maxChangePerSecond;

            StartCoroutine(ScreenShake(enemy.damageValue));

            if (health <= 0)
            {
                //Play death effect, show restart screen.

                Color color = staticPlaneMat.GetColor("_Color");

                color.a = 1;

                staticPlaneMat.SetColor("_Color", color);

            }

            else
            {
                //Set the static to be less transparent.
                Color color = staticPlaneMat.GetColor("_Color");

                color.a = (1 - (health / maxHealth)) * maxStaticWhileAlive;

                staticPlaneMat.SetColor("_Color", color);
            }
        }
    }

    private IEnumerator ScreenShake(float timeToShake)
    {
        float timeLeft = timeToShake;

        Vector3 initCameraPos = Camera.main.transform.localPosition;

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            float ratioLeft = timeLeft / timeToShake;

            Vector3 shakeDelta = new Vector3(Random.Range(-ratioLeft * maxScreenShakeAmount, ratioLeft * maxScreenShakeAmount), Random.Range(-ratioLeft * maxScreenShakeAmount, ratioLeft * maxScreenShakeAmount), 0.0f);

            Camera.main.transform.localPosition = initCameraPos + shakeDelta;

            yield return null;
        }
        Camera.main.transform.localPosition = initCameraPos;
    }
}