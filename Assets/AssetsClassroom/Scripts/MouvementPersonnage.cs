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
            GetComponent<Animator>().Play("WalkingLeft");
           //GetComponent<Animator>().Play("StandingLeft");
        }
        if (Input.GetKey(KeyCode.D) && transform.position == pos){        // Right
            pos += Vector3.right;
            GetComponent<Animator>().Play("WalkingRight");
            //GetComponent<Animator>().Play("StandingRight");
        }
        if (Input.GetKey(KeyCode.Z) && transform.position == pos){        // Up
            pos += Vector3.up;
            GetComponent<Animator>().Play("WalkingUp");
            //GetComponent<Animator>().Play("StandingUp");
        }
        if (Input.GetKey(KeyCode.S) && transform.position == pos){        // Down
            pos += Vector3.down;
            GetComponent<Animator>().Play("WalkingDown");
            //GetComponent<Animator>().Play("StandingDown");
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
    }
}
