using System;
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
            GameObject closestPlayer = closestTarget(GetComponent<Ennemy>().getPos());
            Debug.Log(GetComponent<Ennemy>().getPos().ToString());               
            bool check = moveToClosestPlayer(closestPlayer);
            if (check)
            {
                attackPlayer(closestPlayer);
            }
            
        }
        
    }

    private void attackPlayer(GameObject closestPlayer)
    {
        closestPlayer.GetComponent<CombatJoueur>().getAttacked(GetComponent<Ennemy>().getAttackEnemy());
        Debug.Log("A player got attacked");
    }

    void moveIfNoCloseTargets()
    {

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

    bool moveToClosestPlayer(GameObject closestPlayer)
    {
        /*bool travelEnd = false;
        while (!travelEnd)
        {
        C'est le moment où je pleure ma race
        }*/

        Vector3 toTeleportCalc = closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer() + Vector3.up;
        Vector3 toTeleport =  toTeleportCalc - GetComponent<Ennemy>().getPos();
        GetComponent<Animator>().Play("WalkingDown");
            
        //transform.position = Vector3.MoveTowards(transform.position, GetComponent<Ennemy>().getPos(), Time.deltaTime * GetComponent<Ennemy>().getSpeed());    // Move there
        if (GameObject.FindGameObjectWithTag("MapGenerator").GetComponent<FightMapGenerator>().canWalk(toTeleportCalc))
        {
            Debug.Log("Enemy can move");
            GetComponent<Ennemy>().modifPos(toTeleport);
            transform.Translate(toTeleport);
            return true;
        }
        if (!GameObject.FindGameObjectWithTag("MapGenerator").GetComponent<FightMapGenerator>().canWalk(toTeleportCalc))
        {
            Debug.Log("Enemy can't move");
            return false;
        }
        return false;

    }

    public List<GameObject> whoCanIAttack(Vector3 actualPosition)

    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(players[0].GetComponent<MouvementPersonnage>().getPosPlayer().ToString());
        // GameObject[] possibleTargets = new GameObject[GameObject.FindGameObjectsWithTag("Player").Length];
        List<GameObject> possibleTargets = new List<GameObject>();

        int nbTargets = 0;
        foreach (GameObject ob in players)
        {
            /*Debug.Log("ob.GetComponent<Ennemy>().getPos() : " + ob.GetComponent<MouvementPersonnage>().getPosPlayer().ToString());
            Debug.Log("actualPosition : " + actualPosition.ToString());
            Debug.Log("GetComponent<Ennemy>().getRange() : " + GetComponent<Ennemy>().getRange());
            Debug.Log("GetComponent<Ennemy>().getPMEnemyMax() : " + GetComponent<Ennemy>().getPMEnemyMax());*/
            if ((Vector3.Distance(ob.GetComponent<MouvementPersonnage>().getPosPlayer(), actualPosition) <= GetComponent<Ennemy>().getRange() + GetComponent<Ennemy>().getPMEnemyMax()))
            {
                possibleTargets.Add(ob);
                nbTargets++;
            }
        }
        return possibleTargets;
    }

    public GameObject closestTarget(Vector3 actualPosition)
    {
        List<GameObject> whoCanIAttackResult = whoCanIAttack(actualPosition);
        GameObject closestPlayer = whoCanIAttackResult[0];
        foreach(GameObject ob in whoCanIAttackResult)
        {

            /*Debug.Log("ob.GetComponent<MouvementPersonnage>().getPosPlayer() : " + ob.GetComponent<MouvementPersonnage>().getPosPlayer());
            Debug.Log("closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer() : " + closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer());*/
            if ((Vector3.Distance(ob.GetComponent<MouvementPersonnage>().getPosPlayer(), actualPosition) > Vector3.Distance(closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer(), actualPosition)))

                if ((Vector3.Distance(ob.GetComponent<MouvementPersonnage>().getPosPlayer(), actualPosition) > Vector3.Distance(closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer(), actualPosition)))

                {
                    Vector3 toTeleportCalc = ob.GetComponent<MouvementPersonnage>().getPosPlayer() + Vector3.up;
                    Vector3 toTeleport = toTeleportCalc - GetComponent<Ennemy>().getPos();
                    if (GameObject.FindGameObjectWithTag("MapGenerator").GetComponent<FightMapGenerator>().canWalk(toTeleportCalc))
                    {
                        closestPlayer = ob;
                    }
                   
                    
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
