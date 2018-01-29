using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        string sceneToLoad = GetComponentInParent<LevelStartUI>().sceneName;
        GameManager.instance.player.GetComponent<Player>().AllowPlayerMovement(true);
        SceneManager.LoadScene(sceneToLoad);

    }
}
