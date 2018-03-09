using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : Character {

    Vector3 posEnnemy;                                // For movement
    float speedEnnemy = 2.0f;                         // Speed of movement
    int HPEnnemy = 100;
    int AttackEnnemy = 10;
    int DefenseEnnemy = 0;

    // Use this for initialization
    void Start () {
        posEnnemy = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		if (HPEnnemy <= 0)
        {
            speedEnnemy = 100.0f;
            posEnnemy += 100 * Vector3.up;
            //GetComponent<Animator>().SetTrigger("StandDown");
            GetComponent<Animator>().SetTrigger("WalkDown");
            transform.position = Vector3.MoveTowards(transform.position, posEnnemy, Time.deltaTime * speedEnnemy);
        }
    }

    public void getDamaged(int AttackerAttack)
    {
        HPEnnemy = HPEnnemy - (AttackerAttack - DefenseEnnemy);
    }

    public Vector3 getPos()
    {
        return posEnnemy;
    }
}
