using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [Header("Types")]
    [SerializeField]
    private Email emailPrefab;
    [SerializeField]
    private Image imagePrefab;
    [SerializeField]
    private Video videoPrefab;
    [SerializeField]
    private Messaging messagingPrefab;

    [Header("Sources")]
    public string[] emailTexts;
    public Sprite[] emailIcons;
    public Sprite[] mediaImages;
    public Sprite[] mediaVideos; //TODO: Need to figure out what type of object a video is
    public string[] messagingTexts;
    public Sprite[] messagingIcons;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Create Email!");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Create Media/Image!");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Create Media/Video!");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Create Instant Messaging!");
        }
    }
}
