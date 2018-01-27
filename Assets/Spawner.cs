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
    [SerializeField]
    private string[] emailTexts;
    [SerializeField]
    private Sprite[] emailIcons;
    [SerializeField]
    private Sprite[] mediaImages;
    [SerializeField]
    private Sprite[] mediaVideos; //TODO: Need to figure out what type of object a video is
    [SerializeField]
    private string[] messagingTexts;
    [SerializeField]
    private Sprite[] messagingIcons;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Create Email!");
            Email obj = Instantiate(emailPrefab, Vector3.zero, Quaternion.identity, transform);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Create Media/Image!");
            Image obj = Instantiate(imagePrefab, Vector3.zero, Quaternion.identity, transform);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Create Media/Video!");
            Video obj = Instantiate(videoPrefab, Vector3.zero, Quaternion.identity, transform);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Create Instant Messaging!");
            Messaging obj = Instantiate(messagingPrefab, Vector3.zero, Quaternion.identity, transform);
        }
    }
}
