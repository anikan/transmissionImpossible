using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingSignal : MonoBehaviour {

    public static bool isScrolling = false;
    private bool startedScroll = false;

    private bool scrollOnStart = true;

	// Use this for initialization
	protected virtual void Start () {

        if (scrollOnStart)
        {
            StartScroll();
        }
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {

        if (isScrolling && !startedScroll)
        {
            StartScroll();
        }
		
	}

    public void StopScroll()
    {
        isScrolling = false;
    }

    public void StartScroll()
    {

        if (!startedScroll)
        {
            StartCoroutine(ScrollDown());
        }

        isScrolling = true;
    }

    public IEnumerator ScrollDown()
    {
        startedScroll = true;
        while (true)
        {
            float scrollAmount = Time.deltaTime * GameManager.instance.universalScrollSpeed;
            if (isScrolling)
            {
                Vector3 pos = this.transform.position;
                pos.y -= scrollAmount;
                transform.position = pos;
            }
            yield return null;
        }

    }

}
