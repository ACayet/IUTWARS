using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : Character {

    Vector3 pos;                                // For movement
    float speed = 2.0f;                         // Speed of movement
    int HP = 100;
    int Attack = 10;
    int Defense = 0;

    // Use this for initialization
    void Start () {
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		if (HP <= 0)
        {
            speed = 100.0f;
            pos += 100 * Vector3.up;
            //GetComponent<Animator>().SetTrigger("StandDown");
            GetComponent<Animator>().SetTrigger("WalkDown");
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        }
    }

    public void getDamaged(int AttackerAttack)
    {
        HP = HP - (AttackerAttack - Defense);
    }

    public Vector3 getPos()
    {
        return pos;
    }
}
