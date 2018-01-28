using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public float universalScrollSpeed = 0.02f;

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
		
	}
}
