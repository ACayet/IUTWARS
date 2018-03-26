using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MouvementPersonnage : Character
{
    Vector3 posPlayer;                                // For movement
    float speedPlayer;                         // Speed of movement
    public int PMPlayer;
    bool isSelected;

    // Use this for initialization
    void Start()
    {
        posPlayer = transform.position; // Take the initial position
        speedPlayer = 2.0f;                        // Speed of movement
                                                   
        isSelected = false;
    }

    public Vector3 getPosPlayer()
    {
        return posPlayer;
    }

    public void setSelected(bool b)
    {
        isSelected = b;
        if (PMPlayer < 0)
        {
            posPlayer = new Vector3(0.0f, 0.0f, 0.0f);
            speedPlayer = 0.0f;
        }
        else
        {
            posPlayer = transform.position;
            speedPlayer = 2.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        if (PMPlayer >= 0 && isSelected)
        {
            if (Input.GetKey(KeyCode.Q) && transform.position == posPlayer)
            {        // Left
                posPlayer += Vector3.left;

                GetComponent<Animator>().Play("WalkingLeft");
                //GetComponent<Animator>().Play("StandingLeft");
                PMPlayer = PMPlayer - 1;
            }
            if (Input.GetKey(KeyCode.D) && transform.position == posPlayer)
            {        // Right
                posPlayer += Vector3.right;
                GetComponent<Animator>().Play("WalkingRight");
                //GetComponent<Animator>().Play("StandingRight");
                PMPlayer = PMPlayer - 1;
            }
            if (Input.GetKey(KeyCode.Z) && transform.position == posPlayer)
            {        // Up
                posPlayer += Vector3.up;
                GetComponent<Animator>().Play("WalkingUp");
                //GetComponent<Animator>().Play("StandingUp");
                PMPlayer = PMPlayer - 1;
            }
            if (Input.GetKey(KeyCode.S) && transform.position == posPlayer)
            {        // Down
                posPlayer += Vector3.down;
                GetComponent<Animator>().Play("WalkingDown");
                //GetComponent<Animator>().Play("StandingDown");
                PMPlayer = PMPlayer - 1;

                //GetComponent<Animator>().SetTrigger("StandLeft");

                /*GetComponent<Animator>().SetTrigger("WalkLeft");
                if (PMPlayer <= 0)
                {
                    Debug.Log("T'es mauvais Jack");
                }
                PMPlayer = PMPlayer - 1;*/
            }
            /*if (Input.GetKey(KeyCode.D) && transform.position == posPlayer)
            {        // Right
                posPlayer += Vector3.right;
                //GetComponent<Animator>().SetTrigger("StandRight");
                GetComponent<Animator>().SetTrigger("WalkRight");
                if (PMPlayer <= 0)
                {
                    Debug.Log("T'es nul Jack");
                }
                PMPlayer = PMPlayer - 1;
            }
            if (Input.GetKey(KeyCode.Z) && transform.position == posPlayer)
            {        // Up
                posPlayer += Vector3.up;
                //GetComponent<Animator>().SetTrigger("StandUp");
                GetComponent<Animator>().SetTrigger("WalkUp");
                if (PMPlayer <= 0)
                {
                    Debug.Log("T'es moche Jack");
                }
                PMPlayer = PMPlayer - 1;
            }
            if (Input.GetKey(KeyCode.S) && transform.position == posPlayer)
            {        // Down
                posPlayer += Vector3.down;
                //GetComponent<Animator>().SetTrigger("StandDown");
                GetComponent<Animator>().SetTrigger("WalkDown");
                if (PMPlayer <= 0)
                {
                    Debug.Log("T'es mort Jack");
                }
                PMPlayer = PMPlayer - 1;
            }*/
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, Time.deltaTime * speedPlayer);    // Move there
        }
        /*if (Input.GetKey(KeyCode.Space) && transform.position == posPlayer)
        {

            // GameObject Target = GameObject.Find("Target");
            /*Target.GetComponent<Ennemy>().getDamaged(Attack);*/
        //GameObject[] Targets = whoCanIAttack();
        //AttackTarget(Targets[0]);
        //AttackTarget(Target);
        //if (PA <= 0)
        //{
        //    Debug.Log("T'es faible Jack");
        //}
        //PA = PA - 1;

        //}


    }

    
}
