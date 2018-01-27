using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I strongly recommend against using this script unless you're really really cold, which I am at this moment.

public class LaptopHeater : MonoBehaviour {

    public int heatIntensity = 100;
    GameObject lastCube;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < heatIntensity; i++)
        {

            Debug.Log("Omg it's so cold in here");

            // Some floating point arithmetic just for fun
            float num = Mathf.Pow(200, 100);
            num = num + num;
            num = num / num;
            num = num * Mathf.PI;
            num = Mathf.Sqrt(num);

            Debug.Log("Please get warmer");

        }

        // Make a cube for good measure.
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Vector3 randomPos = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f));
        cube.transform.position = randomPos;

        if (lastCube != null)
        {
            cube.transform.parent = lastCube.transform;
        }

        lastCube = cube;

    }
}
