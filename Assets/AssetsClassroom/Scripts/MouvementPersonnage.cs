using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MouvementPersonnage : Character
{
    Vector3 posPlayer;                                // For movement
    float speedPlayer;                         // Speed of movement
    int HPPlayer;
    int AttackPlayer;
    int DefensePlayer;
    int portéePlayer;
    int PMPlayer;
    int PAPlayer;
    bool isSelected;
    
    // Use this for initialization
    void Start()
    {
        posPlayer = transform.position; // Take the initial position
        speedPlayer = 2.0f;                         // Speed of movement
        HPPlayer = 100;
        AttackPlayer = 10;
        DefensePlayer = 0;
        portéePlayer = 2;
        PMPlayer = 3;
        PAPlayer = 2;
        isSelected = false;
    }

    public Vector3 getPosPlayer()
    {
        return posPlayer;
    }

    public void setSelected(bool b)
    {
        isSelected = b;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Q) && transform.position == posPlayer)
        {        // Left
            posPlayer += Vector3.left;

            GetComponent<Animator>().Play("WalkingLeft");
            //GetComponent<Animator>().Play("StandingLeft");
        }
        if (Input.GetKey(KeyCode.D) && transform.position == posPlayer)
        {        // Right
            posPlayer += Vector3.right;
            GetComponent<Animator>().Play("WalkingRight");
            //GetComponent<Animator>().Play("StandingRight");
        }
        if (Input.GetKey(KeyCode.Z) && transform.position == posPlayer)
        {        // Up
            posPlayer += Vector3.up;
            GetComponent<Animator>().Play("WalkingUp");
            //GetComponent<Animator>().Play("StandingUp");
        }
        if (Input.GetKey(KeyCode.S) && transform.position == posPlayer)
        {        // Down
            posPlayer += Vector3.down;
            GetComponent<Animator>().Play("WalkingDown");
            //GetComponent<Animator>().Play("StandingDown");

            //GetComponent<Animator>().SetTrigger("StandLeft");

            GetComponent<Animator>().SetTrigger("WalkLeft");
            if (PMPlayer <= 0)
            {
                Debug.Log("T'es mauvais Jack");
            }
            PMPlayer = PMPlayer - 1;
        }
        if (Input.GetKey(KeyCode.D) && transform.position == posPlayer)
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
        }
        transform.position = Vector3.MoveTowards(transform.position, posPlayer, Time.deltaTime * speedPlayer);    // Move there
        if (Input.GetKey(KeyCode.Space) && transform.position == posPlayer)
        {

            // GameObject Target = GameObject.Find("Target");
            /*Target.GetComponent<Ennemy>().getDamaged(Attack);*/
            GameObject[] Targets = whoCanIAttack();
            AttackTarget(Targets[0]);
            //AttackTarget(Target);
            //if (PA <= 0)
            //{
            //    Debug.Log("T'es faible Jack");
            //}
            //PA = PA - 1;

        }

       
    }

    void AttackTarget(GameObject theTarget)
    {
        if (isThereAnEnnemyToAttack())
        {
            Debug.Log("JOHN CENA"); theTarget.GetComponent<Ennemy>().getDamaged(AttackPlayer);


        };

    }

    public GameObject[] whoCanIAttack()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
        GameObject[] possibleTargets = new GameObject[targetNumber(portéePlayer)];
        int nbTargets = 0;
        foreach (GameObject ob in ennemies)
        {
            if ((Vector3.Distance(ob.GetComponent<Ennemy>().getPos(), posPlayer) <= portéePlayer))
            {
                possibleTargets[nbTargets] = ob;
                nbTargets++;
            }
        }
        return possibleTargets;
    }

    public bool isThereAnEnnemyToAttack()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Ennemy");

        foreach (GameObject ob in ennemies)
        {
            if ((Vector3.Distance(ob.GetComponent<Ennemy>().getPos(), posPlayer) <= portéePlayer))
            {
                return true;
            }
        }
        return false;
    }

    public int targetNumber(int range)
    {
        int targetNb = 0;
        for (int i = 1; i <= range; i++)
        {
            targetNb = targetNb + (i * 4);

        }
        return targetNb;
    }
}
