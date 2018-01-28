using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {

    public GameObject thisCanvas;
    public GameObject gameStartCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoBack()
    {
        gameStartCanvas.SetActive(true);
        thisCanvas.SetActive(false);
    }
}
