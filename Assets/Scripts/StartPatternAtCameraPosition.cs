using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPatternAtCameraPosition : MonoBehaviour {

    public GameObject patternToActivate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);

        if (collision.GetComponent<Camera>())
        {
            patternToActivate.SetActive(true);
        }
    }
}
