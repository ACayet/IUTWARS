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
           
            if (!checkIfCaseOccupied(closestPlayer))
            {
                
                moveToClosestPlayer(closestPlayer);
            }
        }
        
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

    void moveToClosestPlayer(GameObject closestPlayer)
    {
        /*bool travelEnd = false;
        while (!travelEnd)
        {
        C'est le moment où je pleure ma race
        }*/

        Vector3 toTeleportCalc = closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer() + Vector3.up;
        Vector3 toTeleport =  toTeleportCalc - GetComponent<Ennemy>().getPos();
        if (!checkIfCaseOccupied(closestPlayer))
        {
            GetComponent<Animator>().Play("WalkingDown");
            Debug.Log(toTeleport.ToString());
            Debug.Log(closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer().ToString());
            GetComponent<Ennemy>().modifPos(toTeleport);
            //transform.position = Vector3.MoveTowards(transform.position, GetComponent<Ennemy>().getPos(), Time.deltaTime * GetComponent<Ennemy>().getSpeed());    // Move there
            transform.Translate(toTeleport);
        }
    }

    bool checkIfCaseOccupied(GameObject Target)
    {
        /* float radius = 0f;
         if (Physics.CheckSphere(vector, radius)){
             Debug.Log("There's something here");
             return true;
         }
         else return false;*/
       /* GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ennemy");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject ob in enemies)
        {
            if(ob.GetComponent<Ennemy>().getPos() == (GetComponent<Ennemy>().getPos() + vector))
            {
                Debug.Log("Ally found if move of " + vector.ToString());
                return true;
            }
            
        }
        foreach (GameObject ob in players)
        {
            if (ob.GetComponent<MouvementPersonnage>().getPosPlayer() == (GetComponent<Ennemy>().getPos() + vector))
            {
                Debug.Log("Target found if move of " + vector.ToString());
                return true;
            }

        }
        return false;*/
        var hitColliders = Physics.OverlapSphere((Target.GetComponent<MouvementPersonnage>().getPosPlayer()), 1,5);//1 is purely chosen arbitrarly
        if (hitColliders.Length > 0)
        {
            Debug.Log("Can't move, found something");
            return true;
        }
        Debug.Log("Can move, found nothing");
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
                    if (!checkIfCaseOccupied(ob))
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
