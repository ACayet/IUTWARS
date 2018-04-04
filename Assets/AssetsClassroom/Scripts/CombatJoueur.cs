using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatJoueur : MonoBehaviour {

    public int HPPlayer;
    public int HPPlayerMax;
    public int AttackPlayer;
    public int DefensePlayer;
    public int portéePlayer;
    Vector3 PlayerPosition;
    public int PAPlayer;
    public int PAPlayerMax;
    public string characterName;

    // Use this for initialization
    void Start () {
        setPAPlayertotheMax();
        setHPTotheMax();
	}

    private void setHPTotheMax()
    {
        HPPlayer = HPPlayerMax;
    }

    // Update is called once per frame
    void Update () {
		
	}
   
    public void getAttacked(int AttackOfTheEnemy)
    {
        HPPlayer = HPPlayer - (AttackOfTheEnemy - DefensePlayer);
        Debug.Log(characterName + " a perdu " + (AttackOfTheEnemy - DefensePlayer) + " Points de Vie");
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

    public void getPositionOfPlayer(Vector3 position)
    {
        PlayerPosition = position;
    }

    internal int getAttack()
    {
        return AttackPlayer;
    }

    public void AttackTarget(GameObject theTarget)
    {
        //Debug.Log("Attack initiated");
        if (isThereAnEnnemyToAttack(transform.position) && PAPlayer > 0)
        {
            //Debug.Log("Target found");
            if (canIAttackThis(theTarget, whoCanIAttack(transform.position)))
            {
                //Debug.Log("JOHN CENA");
                theTarget.GetComponent<Ennemy>().getDamaged(AttackPlayer);
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

    public GameObject[] whoCanIAttack(Vector3 actualPosition)
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
        GameObject[] possibleTargets = new GameObject[targetNumber(portéePlayer)];
        int nbTargets = 0;
        foreach (GameObject ob in ennemies)
        {
            if ((Vector3.Distance(ob.GetComponent<Ennemy>().getPos(), actualPosition) <= portéePlayer))
            {
                possibleTargets[nbTargets] = ob;
                nbTargets++;
            }
        }
        return possibleTargets;
    }

    public bool isThereAnEnnemyToAttack(Vector3 actualPosition)
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Ennemy");

        foreach (GameObject ob in ennemies)
        {
           // Debug.Log(Vector3.Distance(ob.GetComponent<Ennemy>().getPos(), actualPosition).ToString() + " VS " + portéePlayer);
            if ((Vector3.Distance(ob.GetComponent<Ennemy>().getPos(), actualPosition) <= portéePlayer))
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
