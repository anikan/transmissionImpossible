using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToNextLevel()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int allSceneCount = SceneManager.sceneCount;
        int numNonMenuScenes = allSceneCount - 1;

        int sceneToLoad = 1;

        if (currentSceneIndex < numNonMenuScenes)
        {
            sceneToLoad = currentSceneIndex + 1;

        }

        SceneManager.LoadScene(sceneToLoad);

    }
}
