using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartUI : MonoBehaviour {

    public GameObject gameStartCanvas;
    public GameObject levelSelectCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartMission()
    {
        levelSelectCanvas.SetActive(true);
        gameStartCanvas.SetActive(false);
    }
}
