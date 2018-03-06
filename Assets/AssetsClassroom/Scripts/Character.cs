using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    Vector3 pos;                                // For movement
    float speed = 2.0f;                         // Speed of movement
    int HP = 100;
    int Attack = 10;
    int Defense = 0;

    // Use this for initialization
    void Start()
    {
        pos = transform.position; // Take the initial position
    }

    // Update is called once per frame
    void Update () {
		//Dependent on the type of character
	}
}
