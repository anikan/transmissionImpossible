using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject player;

    public float universalScrollSpeed = 1.5f;
    public float gameTimeScale = 1.0f;

    public void Awake()
    {

        if (!instance)
        {
            instance = this;
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
            
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Time.timeScale = gameTimeScale;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            gameTimeScale += 0.2f;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameTimeScale -= 0.2f;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameTimeScale = 1.0f;
        }

	}
}
