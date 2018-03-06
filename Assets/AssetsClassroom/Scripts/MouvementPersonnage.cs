using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementPersonnage : Character {
    Vector3 pos;                                // For movement
    float speed = 2.0f;                         // Speed of movement
    int HP = 100;
    int Attack = 10;
    int Defense = 0;
    int portée = 1;
    int PM = 3;
    int PA = 2;

    // Use this for initialization
    void Start()
    {
        pos = transform.position; // Take the initial position
        
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Q) && transform.position == pos){        // Left
            pos += Vector3.left;
            //GetComponent<Animator>().SetTrigger("StandLeft");
            
            GetComponent<Animator>().SetTrigger("WalkLeft");
            if(PM <= 0)
            {
                print("T'es mauvais Jack");
            }
            PM = PM - 1;
        }
        if (Input.GetKey(KeyCode.D) && transform.position == pos){        // Right
            pos += Vector3.right;
            //GetComponent<Animator>().SetTrigger("StandRight");
            GetComponent<Animator>().SetTrigger("WalkRight");
            if (PM <= 0)
            {
                print("T'es nul Jack");
            }
            PM = PM - 1;
        }
        if (Input.GetKey(KeyCode.Z) && transform.position == pos){        // Up
            pos += Vector3.up;
            //GetComponent<Animator>().SetTrigger("StandUp");
            GetComponent<Animator>().SetTrigger("WalkUp");
            if (PM <= 0)
            {
                print("T'es moche Jack");
            }
            PM = PM - 1;
        }
        if (Input.GetKey(KeyCode.S) && transform.position == pos){        // Down
            pos += Vector3.down;
            //GetComponent<Animator>().SetTrigger("StandDown");
            GetComponent<Animator>().SetTrigger("WalkDown");
            if (PM <= 0)
            {
                print("T'es mort Jack");
            }
            PM = PM - 1;
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
        if (Input.GetKey(KeyCode.Space) && transform.position == pos)
        {
            
            GameObject Target = GameObject.Find("Target");
            /*Target.GetComponent<Ennemy>().getDamaged(Attack);*/
            AttackTarget(Target);
            //if (PA <= 0)
            //{
            //    print("T'es faible Jack");
            //}
            //PA = PA - 1;
           
        }
    }

    void AttackTarget(GameObject theTarget)
    {
        if (isThereAnEnnemyToAttack()) { print("JOHN CENA"); theTarget.GetComponent<Ennemy>().getDamaged(Attack); };
        
    }

    public GameObject[] whoCanIAttack()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
        GameObject[] possibleTargets = new GameObject[targetNumber(portée)];
        int nbTargets = 0;
        foreach(GameObject ob in ennemies)
        {
            if ((Vector3.Distance(ob.GetComponent<Ennemy>().getPos(), pos) <= portée)){
                possibleTargets[nbTargets] = ob;
            }
        }
        return possibleTargets;
    }

    public bool isThereAnEnnemyToAttack()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
       
        foreach (GameObject ob in ennemies)
        {
            if ((Vector3.Distance(ob.GetComponent<Ennemy>().getPos(), pos) <= portée))
            {
               return true;
            }
        }
        return false;
    }

    public int targetNumber(int range)
    {
        int targetNb = 0;
        for(int i = 1; i == range; i++)
        {
            targetNb = targetNb + i * 4;
        }
        return targetNb;
    }
}
