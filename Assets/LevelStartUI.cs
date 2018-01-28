using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelStartUI : MonoBehaviour {

    public string sceneName;
    public string levelName;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitializeLevelStartUI(string sceneName, string levelName)
    {

        this.sceneName = sceneName;
        this.levelName = levelName;
    }
}
