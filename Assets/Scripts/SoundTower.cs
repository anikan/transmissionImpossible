using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTower : MonoBehaviour {

    private Color pulseColor;
    private TowerAudioClip clip;
    public GameObject pulseObject;

    private bool pulsing = true;

	// Use this for initialization
	void Start ()
    {

        InitializeTower();

	}

    // Update is called once per frame
    void Update()
    {



    }

    public void InitializeTower()
    {

        clip = SoundManager.instance.allClips[Random.Range(0, SoundManager.instance.allClips.Count)];
        pulseColor = new Color(Random.Range(0.0f, 0.0f), Random.Range(0.0f, 0.0f), Random.Range(0.0f, 0.0f));

        float timeUntilFirstBeat = (clip.timeBetweenBeats - clip.bpmOffset) % clip.timeBetweenBeats;
        float startingScalePoint = timeUntilFirstBeat / clip.timeBetweenBeats;

        float pulseMidpoint = (SoundManager.instance.pulseMinRadius + SoundManager.instance.pulseMaxRadius) * startingScalePoint;
        pulseObject.transform.localScale = new Vector3(pulseMidpoint, pulseMidpoint, pulseMidpoint);

        PlayAudio();
        StartCoroutine(Pulse());

    }

    public void PlayAudio()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.clip = clip.audioClip;
        source.loop = true;
        source.Play();
    }

    public IEnumerator Pulse()
    {

        float timeToNextBeat = (clip.timeBetweenBeats - clip.bpmOffset) % clip.timeBetweenBeats;

        while (pulsing)
        {

            Vector3 startingPulseScale = new Vector3(SoundManager.instance.pulseMinRadius, SoundManager.instance.pulseMinRadius, SoundManager.instance.pulseMinRadius);
            Vector3 endingPulseScale = new Vector3(SoundManager.instance.pulseMaxRadius, SoundManager.instance.pulseMaxRadius, SoundManager.instance.pulseMaxRadius);

            for (float i = 0; i < timeToNextBeat; i += Time.deltaTime)
            {

                pulseObject.transform.localScale = Vector3.Lerp(startingPulseScale, endingPulseScale, i / timeToNextBeat);
                yield return null;

            }

            timeToNextBeat = clip.timeBetweenBeats;
            Debug.Log("Time to next beat 2 is " + timeToNextBeat);

            pulseObject.transform.localScale = endingPulseScale;


            for (float i = 0; i < timeToNextBeat * 0.75f; i += Time.deltaTime)
            {

                float interpolant = i / (timeToNextBeat / 2.0f);
                pulseObject.transform.localScale = Vector3.Lerp(endingPulseScale, startingPulseScale, interpolant);
                yield return null;


            }

            pulseObject.transform.localScale = startingPulseScale;
            timeToNextBeat = clip.timeBetweenBeats * 0.25f;
            Debug.Log("Time to next beat 3 is " + timeToNextBeat);
        

        }
    }
}
