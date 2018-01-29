using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {

    public string sceneName;
    public string levelName = "<Level Name>";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel()
    {

        GameObject newLevelUI = GameObject.Instantiate(GetComponentInParent<LevelSelectUI>().levelStartPrefab) as GameObject;
        newLevelUI.SetActive(true);
        newLevelUI.GetComponentInChildren<LevelStartUI>().InitializeLevelStartUI(sceneName, levelName);
        GetComponentInParent<LevelSelectUI>().gameObject.SetActive(false);
    }
}
