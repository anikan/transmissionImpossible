using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingSignal : MonoBehaviour {

    protected bool isScrolling = true;
    private bool startedScroll = false;
    public bool scrollOnStart = true;

	// Use this for initialization
	protected virtual void Start () {

        if (scrollOnStart)
        {
            StartScroll();
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
