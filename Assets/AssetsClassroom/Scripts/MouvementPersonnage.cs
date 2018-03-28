﻿using System;
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
    public int PMPlayerMax;

    // Use this for initialization
    void Start()
    {
        posPlayer = transform.position; // Take the initial position
        speedPlayer = 2.0f;                        // Speed of movement

        setPMtotheMax();                    
        isSelected = false;
    }

    public void setPMtotheMax()
    {
        PMPlayer = PMPlayerMax;
    }

    public float getSpeedPlayer()
    {
        return speedPlayer;
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
                
                PMPlayer = PMPlayer - 1;
            }
            if (Input.GetKey(KeyCode.D) && transform.position == posPlayer)
            {        // Right
                posPlayer += Vector3.right;
                GetComponent<Animator>().Play("WalkingRight");
                
                PMPlayer = PMPlayer - 1;
            }
            if (Input.GetKey(KeyCode.Z) && transform.position == posPlayer)
            {        // Up
                posPlayer += Vector3.up;
                GetComponent<Animator>().Play("WalkingUp");
                
                PMPlayer = PMPlayer - 1;
            }
            if (Input.GetKey(KeyCode.S) && transform.position == posPlayer)
            {        // Down
                posPlayer += Vector3.down;
                GetComponent<Animator>().Play("WalkingDown");
                
                PMPlayer = PMPlayer - 1;
            }  
            
            transform.position = Vector2.MoveTowards(transform.position, posPlayer, Time.deltaTime * speedPlayer);    // Move there
        }   
    }  
}
