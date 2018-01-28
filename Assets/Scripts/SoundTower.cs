using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTower : ScrollingSignal {

    public bool randomAudioClip = true;
    public bool randomColor = true;
    public GameObject pulseObject;
    public GameObject outerFadePulse;
    public Color pulseColor = Color.red;
    public int audioClipIndex;

    private TowerAudioClip clip;

    private bool pulsing = false;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();

        // TODO: Remove later. Towers shouldn't immediately initialize.
        //InitializeTower();

	}

    // Update is called once per frame
    void Update()
    {

        float distanceFromStage = Vector3.Distance(transform.position, GameManager.instance.transform.position);

        if (!pulsing && distanceFromStage <= SoundManager.instance.activationDistanceFromStage)
        {

            InitializeTower();

        }

        else if (pulsing)
        {

            if (distanceFromStage > SoundManager.instance.activationDistanceFromStage)
            {
                GameObject.Destroy(gameObject);
            }

            GetComponent<AudioSource>().volume = clip.volume;
        }

    }

    // Initializes a tower to start it playing and pulsing music
    public void InitializeTower()
    {
        // Get the clip and color randomly from sound manager.
        // May want to make this non-random later.
        if (randomAudioClip)
        {
            audioClipIndex = Random.Range(0, SoundManager.instance.allClips.Count);
        }


        clip = SoundManager.instance.allClips[audioClipIndex];

        if (randomColor)
        {
            pulseColor = new Color(Random.Range(0.3f, 1.0f), Random.Range(0.3f, 1.0f), Random.Range(0.3f, 1.0f));
        }

        // Calculate what size the pulse should start at.
        float timeUntilFirstBeat = (clip.timeBetweenBeats - clip.bpmOffset) % clip.timeBetweenBeats;
        float startingScalePoint = timeUntilFirstBeat / clip.timeBetweenBeats;
        float pulseMidpoint = (SoundManager.instance.pulseMinRadius + SoundManager.instance.pulseMaxRadius) * startingScalePoint;
        pulseObject.transform.localScale = new Vector3(pulseMidpoint, pulseMidpoint, pulseMidpoint);

        // Set the color of the pulse.
        pulseObject.GetComponent<SpriteRenderer>().color = pulseColor;
        outerFadePulse.GetComponent<SpriteRenderer>().color = pulseColor;

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
        source.volume = clip.volume;
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

            outerFadePulse.transform.localScale = Vector3.zero;

            // Starting and ending scales of the sprite.
            Vector3 startingPulseScale = new Vector3(SoundManager.instance.pulseMinRadius, SoundManager.instance.pulseMinRadius, SoundManager.instance.pulseMinRadius);
            Vector3 endingPulseScale = new Vector3(SoundManager.instance.pulseMaxRadius, SoundManager.instance.pulseMaxRadius, SoundManager.instance.pulseMaxRadius);


            Color startOuterPulseColor = outerFadePulse.GetComponent<SpriteRenderer>().color;
            startOuterPulseColor.a = 0.5f;

            Color endOuterPulseColor = startOuterPulseColor;
            endOuterPulseColor.a = 0.0f;

            // Grow the sprite to hit the beat.
            for (float i = 0; i < timeToNextBeat; i += Time.deltaTime)
            {

                // Lerp the scale of the object.
                pulseObject.transform.localScale = Vector3.Lerp(startingPulseScale, endingPulseScale, i / timeToNextBeat);

                outerFadePulse.GetComponent<SpriteRenderer>().color = Color.Lerp(startOuterPulseColor, endOuterPulseColor, i / timeToNextBeat);

                Vector3 outerPulseScale = new Vector3(SoundManager.instance.outerPulseDist, SoundManager.instance.outerPulseDist, SoundManager.instance.outerPulseDist);

                outerFadePulse.transform.localScale = Vector3.Lerp(Vector3.zero, outerPulseScale, i / timeToNextBeat);

                yield return null;

            }

            outerFadePulse.GetComponent<SpriteRenderer>().color = endOuterPulseColor;



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
