﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatJoueur : MonoBehaviour {

    public int HPPlayer;
    public int AttackPlayer;
    public int DefensePlayer;
    public int portéePlayer;
    Vector2 PlayerPosition;
    public int PAPlayer;
    public int PAPlayerMax;

    // Use this for initialization
    void Start () {
        setPAPlayertotheMax();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
    public void setPAPlayertotheMax()
    {
        PAPlayer = PAPlayerMax;
    }

    public int getPAPlayer()
    {
        return PAPlayer;
    }

    public void resetPAPlayer()
    {
        PAPlayer = PAPlayerMax;
    }

    public void getPositionOfPlayer(Vector2 position)
    {
        PlayerPosition = position;
    }

    internal int getAttack()
    {
        return AttackPlayer;
    }

    public void AttackTarget(GameObject theTarget)
    {
        
        if (isThereAnEnnemyToAttack(PlayerPosition) && PAPlayer > 0)
        {
            if (canIAttackThis(theTarget, whoCanIAttack(PlayerPosition)))
            {
                Debug.Log("JOHN CENA"); theTarget.GetComponent<Ennemy>().getDamaged(AttackPlayer);
                PAPlayer = PAPlayer - 1;
            }



        };

    }

    public bool canIAttackThis(GameObject clickedTarget, GameObject[] possibleTargets)
    {
        foreach (GameObject ob in possibleTargets)
        {
            if (ob == clickedTarget)
            {
                return true;
            }
        }
        return false;
    }

    public GameObject[] whoCanIAttack(Vector2 actualPosition)
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
        GameObject[] possibleTargets = new GameObject[targetNumber(portéePlayer)];
        int nbTargets = 0;
        foreach (GameObject ob in ennemies)
        {
            if ((Vector2.Distance(ob.GetComponent<Ennemy>().getPos(), actualPosition) <= portéePlayer))
            {
                possibleTargets[nbTargets] = ob;
                nbTargets++;
            }
        }
        return possibleTargets;
    }

    public bool isThereAnEnnemyToAttack(Vector2 actualPosition)
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Ennemy");

        foreach (GameObject ob in ennemies)
        {
            if ((Vector2.Distance(ob.GetComponent<Ennemy>().getPos(), actualPosition) <= portéePlayer))
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
