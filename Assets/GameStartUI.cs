using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartUI : MonoBehaviour {

    public static bool shownOnce = false;

    public GameObject gameStartCanvas;
    public GameObject levelSelectCanvas;

    void Awake()
    {

        if (!shownOnce)
        {
            shownOnce = true;
            gameStartCanvas.SetActive(true);
        }
        else
        {
            gameStartCanvas.SetActive(false);
            levelSelectCanvas.SetActive(true);
        }

    }

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
