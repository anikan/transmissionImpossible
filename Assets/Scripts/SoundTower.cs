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

        // TODO: Remove later. Towers shouldn't immediately initialize.
        InitializeTower();

	}

    // Update is called once per frame
    void Update()
    {



    }

    // Initializes a tower to start it playing and pulsing music
    public void InitializeTower()
    {
        // Get the clip and color randomly from sound manager.
        // May want to make this non-random later.
        clip = SoundManager.instance.allClips[Random.Range(0, SoundManager.instance.allClips.Count)];
        pulseColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

        // Calculate what size the pulse should start at.
        float timeUntilFirstBeat = (clip.timeBetweenBeats - clip.bpmOffset) % clip.timeBetweenBeats;
        float startingScalePoint = timeUntilFirstBeat / clip.timeBetweenBeats;
        float pulseMidpoint = (SoundManager.instance.pulseMinRadius + SoundManager.instance.pulseMaxRadius) * startingScalePoint;
        pulseObject.transform.localScale = new Vector3(pulseMidpoint, pulseMidpoint, pulseMidpoint);

        // Set the color of the pulse.
        pulseObject.GetComponent<SpriteRenderer>().color = pulseColor;

        // Start audio playing.
        PlayAudio();

        // Begin pulse.
        StartCoroutine(Pulse());

    }

    // Begin playing clip audio.
    public void PlayAudio()
    {
        // Get the audio source, set the clip, and play the audio.
        AudioSource source = GetComponent<AudioSource>();
        source.clip = clip.audioClip;
        source.loop = true;
        source.Play();
    }

    // Pulse a sprite to the beat of the song
    public IEnumerator Pulse()
    {
        // Set the pulsing flag.
        pulsing = true;

        // Calculate initial time to the next beat.
        float timeToNextBeat = (clip.timeBetweenBeats - clip.bpmOffset) % clip.timeBetweenBeats;

        while (pulsing)
        {

            // Starting and ending scales of the sprite.
            Vector3 startingPulseScale = new Vector3(SoundManager.instance.pulseMinRadius, SoundManager.instance.pulseMinRadius, SoundManager.instance.pulseMinRadius);
            Vector3 endingPulseScale = new Vector3(SoundManager.instance.pulseMaxRadius, SoundManager.instance.pulseMaxRadius, SoundManager.instance.pulseMaxRadius);

            // Grow the sprite to hit the beat.
            for (float i = 0; i < timeToNextBeat; i += Time.deltaTime)
            {

                // Lerp the scale of the object.
                pulseObject.transform.localScale = Vector3.Lerp(startingPulseScale, endingPulseScale, i / timeToNextBeat);
                yield return null;

            }
            
            // Just finished growing, so time to next beat is full time between beats.
            timeToNextBeat = clip.timeBetweenBeats;

            // Snap the object scale.
            pulseObject.transform.localScale = endingPulseScale;

            // Shrink the sprite down before next beat. 75% of time should be sent shrinking, 25% spent growing (for faster beat hits)
            for (float i = 0; i < timeToNextBeat * 0.75f; i += Time.deltaTime)
            {

                // Calculate amount of shrinking this loop iteration.
                float interpolant = i / (timeToNextBeat / 2.0f);
                pulseObject.transform.localScale = Vector3.Lerp(endingPulseScale, startingPulseScale, interpolant);
                yield return null;


            }

            // Snap the scale to the smallest size.
            pulseObject.transform.localScale = startingPulseScale;

            // Time to the beat should now be 25% of time between beats, the time it takes to grow next loop iteration.
            timeToNextBeat = clip.timeBetweenBeats * 0.25f;      

        }
    }
}
