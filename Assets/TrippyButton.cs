using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrippyButton : MonoBehaviour {

    public float colorChangeDuration = 1.0f;

    public Color buttonColor
    {

        get
        {
           return GetComponent<UnityEngine.UI.Image>().color;
            
        }
        set
        {
            GetComponent<UnityEngine.UI.Image>().color = value;
        }

    }

	// Use this for initialization
	void Start () {

        StartCoroutine(TripOut());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator TripOut()
    {

        while (true)
        {
            Color startColor = buttonColor;
            Color endColor = new Color(Random.Range(0.3f, 1.0f), Random.Range(0.3f, 1.0f), Random.Range(0.3f, 1.0f));

            for (float i = 0; i < colorChangeDuration; i+= Time.deltaTime)
            {
                buttonColor = Color.Lerp(startColor, endColor, i / colorChangeDuration);
                yield return null;
            }

            buttonColor = endColor;

        }



    }
}
