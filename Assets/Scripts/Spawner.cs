﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Spawner : MonoBehaviour {

    [Header("Types")]
    [SerializeField]
    private Email emailPrefab;
    [SerializeField]
    private Image[] imagePrefabs;
    [SerializeField]
    private Video[] videoPrefabs;
    [SerializeField]
    private Messaging[] messagingPrefabs;

    [Header("Sources")]
    public string[] emailTexts;
    public Sprite[] emailIcons;
    public AudioClip[] emailSounds;
    public Sprite[] mediaImages;
    public AudioClip[] mediaImagesSounds;
    public VideoClip[] mediaVideos; //TODO: Need to figure out what type of object a video is
    public string[] messagingTexts;
    public Sprite[] messagingIcons;
    public AudioClip[] messagingSounds;

    [Header("Properties")]
    public float emailSpeed;
    public float imageSpeed;
    public float videoSpeed;
    public float messagingSpeed;

}
