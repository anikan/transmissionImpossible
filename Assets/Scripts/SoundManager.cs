using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TowerAudioClip
{
    public AudioClip audioClip;
    public float bpm;
    public float bpmOffset;

    public float timeBetweenBeats
    {

        get
        {
            float beatsPerSecond = bpm / 60.0f;
            float timeBetweenBeats = 1.0f / beatsPerSecond;
            return timeBetweenBeats;
        }

    }

}




public class SoundManager : MonoBehaviour {

    public static SoundManager instance;
    public float pulseMaxRadius = 1.0f;
    public float pulseMinRadius = 0.1f;

    [SerializeField] public List<TowerAudioClip> allClips;

    private void Awake()
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
