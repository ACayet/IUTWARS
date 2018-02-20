using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementPersonnage : MonoBehaviour {
    Vector3 pos;                                // For movement
    float speed = 2.0f;                         // Speed of movement

    // Use this for initialization
    void Start () {
        pos = transform.position; // Take the initial position
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q) && transform.position == pos){        // Left
            pos += Vector3.left;
            //GetComponent<Animator>().SetTrigger("StandLeft");
            GetComponent<Animator>().SetTrigger("WalkLeft");
        }
        if (Input.GetKey(KeyCode.D) && transform.position == pos){        // Right
            pos += Vector3.right;
            //GetComponent<Animator>().SetTrigger("StandRight");
            GetComponent<Animator>().SetTrigger("WalkRight");
        }
        if (Input.GetKey(KeyCode.Z) && transform.position == pos){        // Up
            pos += Vector3.up;
            //GetComponent<Animator>().SetTrigger("StandUp");
            GetComponent<Animator>().SetTrigger("WalkUp");
        }
        if (Input.GetKey(KeyCode.S) && transform.position == pos){        // Down
            pos += Vector3.down;
            //GetComponent<Animator>().SetTrigger("StandDown");
            GetComponent<Animator>().SetTrigger("WalkDown");
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
    }
}
