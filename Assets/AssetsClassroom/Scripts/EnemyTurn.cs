using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    
    public void AttackTime()
    {
        if (isThereAPlayerToAttack(GetComponent<Ennemy>().getPos()))
        {
            moveToClosestPlayer(closestTarget(GetComponent<Ennemy>().getPos()));
        }
        
    }

    public int targetNumberEnemy()
    {
        int targetNb = 0;
        for (int i = 1; i <= GetComponent<Ennemy>().getRange() + GetComponent<Ennemy>().getPMEnemyMax(); i++)
        {
            targetNb = targetNb + (i * 4);

        }
        return targetNb;
    }

    void moveToClosestPlayer(GameObject closestPlayer)
    {
        /*bool travelEnd = false;
        while (!travelEnd)
        {
        C'est le moment où je pleure ma race
        }*/
        Vector3 toTeleport = closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer() + Vector3.up;
        transform.position = Vector3.MoveTowards(transform.position, toTeleport, Time.deltaTime * GetComponent<Ennemy>().getSpeed());    // Move there
    }

    public GameObject[] whoCanIAttack(Vector3 actualPosition)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] possibleTargets = new GameObject[targetNumberEnemy()];
        int nbTargets = 0;
        foreach (GameObject ob in players)
        {
            if ((Vector3.Distance(ob.GetComponent<Ennemy>().getPos(), actualPosition) <= GetComponent<Ennemy>().getRange() + GetComponent<Ennemy>().getPMEnemyMax()))
            {
                possibleTargets[nbTargets] = ob;
                nbTargets++;
            }
        }
        return possibleTargets;
    }

    public GameObject closestTarget(Vector3 actualPosition)
    {
        GameObject[] whoCanIAttackResult = whoCanIAttack(actualPosition);
        GameObject closestPlayer = whoCanIAttackResult[0];
        foreach(GameObject ob in whoCanIAttackResult)
        {
            if((Vector3.Distance(ob.GetComponent<MouvementPersonnage>().getPosPlayer(), actualPosition) > Vector3.Distance(closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer(), actualPosition)))
            {
                closestPlayer = ob;
            }
        }
        return closestPlayer;
    }

    public bool isThereAPlayerToAttack(Vector3 actualPosition)
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject ob in ennemies)
        {
            if ((Vector3.Distance(ob.GetComponent<MouvementPersonnage>().getPosPlayer(), actualPosition) <= GetComponent<Ennemy>().getRange() + GetComponent<Ennemy>().getPMEnemyMax()))
            {
                return true;
            }
        }
        return false;
    }
}
