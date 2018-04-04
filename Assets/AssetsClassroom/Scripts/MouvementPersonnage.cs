using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MouvementPersonnage : Character
{
    public Vector3 posPlayer;                                // For movement
    float speedPlayer;                         // Speed of movement
    public int PMPlayer;
    public bool isSelected;

    internal void getOutOfScene()
    {
        transform.Translate(new Vector3(500.0f, 500.0f, 0.0f));
    }

    public int PMPlayerMax;
    Vector3 lastWalk;
    // Use this for initialization
    void Start()
    {
        posPlayer = transform.position; // Take the initial position
        speedPlayer = 2.0f;                        // Speed of movement
        lastWalk = transform.position;
        setPMtotheMax();                    
        isSelected = false;
    }

    public void setPMtotheMax()
    {
        PMPlayer = PMPlayerMax;
    }

    public int getPM()
    {
        return PMPlayer;
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
                Mouvement(posPlayer);
                //PMPlayer = PMPlayer - 1;
            }
            if (Input.GetKey(KeyCode.D) && transform.position == posPlayer)
            {        // Right
                posPlayer += Vector3.right;
                GetComponent<Animator>().Play("WalkingRight");
                Mouvement(posPlayer);
                //PMPlayer = PMPlayer - 1;
            }
            if (Input.GetKey(KeyCode.Z) && transform.position == posPlayer)
            {        // Up
                posPlayer += Vector3.up;
                GetComponent<Animator>().Play("WalkingUp");
                Mouvement(posPlayer);
                //PMPlayer = PMPlayer - 1;
            }
            if (Input.GetKey(KeyCode.S) && transform.position == posPlayer)
            {        // Down
                posPlayer += Vector3.down;
                GetComponent<Animator>().Play("WalkingDown");
                Mouvement(posPlayer);
                //PMPlayer = PMPlayer - 1;
            }
            //Mouvement(posPlayer);
            transform.position = Vector3.MoveTowards(transform.position, lastWalk, Time.deltaTime * speedPlayer);    // Move there
            //Debug.Log(posPlayer.ToString());
        }   
    }
    
    void Mouvement(Vector3 dpl)
    {
        if (GameObject.FindGameObjectWithTag("MapGenerator").GetComponent<FightMapGenerator>().canWalk(dpl))
        {
            PMPlayer = PMPlayer - 1;
            //transform.position = Vector3.MoveTowards(transform.position, dpl, Time.deltaTime * speedPlayer);
            lastWalk = dpl;
            
        }
    }
}
