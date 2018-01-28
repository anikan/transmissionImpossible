using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendSignalButton : MonoBehaviour {

    public GameObject UICanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartLevel()
    {


        GameManager.instance.player.GetComponent<Player>().canMove = true;
        ScrollingSignal.isScrolling = true;
        UICanvas.SetActive(false);

    }
}
