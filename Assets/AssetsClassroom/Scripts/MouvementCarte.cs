using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MouvementCarte : Character
{
    Vector3 posPlayer;                                // For movement
    float speedPlayer;                         // Speed of movement
   

    // Use this for initialization
    void Start()
    {
        posPlayer = transform.position; // Take the initial position
        speedPlayer = 2.0f;                         // Speed of movement
                                                    /* HPPlayer = 100;
                                                     AttackPlayer = 10;
                                                     DefensePlayer = 0;
                                                     portéePlayer = 2;
                                                     PMPlayer = 3;
                                                     PAPlayer = 2; */
        
    }

    public Vector3 getPosPlayer()
    {
        return posPlayer;
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
                
            
            }
           
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, Time.deltaTime * speedPlayer);    // Move there
        }
      

    }

    

  

   

   

 
 
