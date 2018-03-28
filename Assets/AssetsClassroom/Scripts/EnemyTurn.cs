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
        Vector2 toTeleport = closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer() + Vector2.up;
        GetComponent<Animator>().Play("WalkingDown");
        Debug.Log(toTeleport.ToString());
        Debug.Log(closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer().ToString());
        GetComponent<Ennemy>().modifPos(Vector2.down);
        transform.position = Vector2.MoveTowards(transform.position, GetComponent<Ennemy>().getPos(), Time.deltaTime * GetComponent<Ennemy>().getSpeed());    // Move there
    }

    public List<GameObject> whoCanIAttack(Vector2 actualPosition)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        // GameObject[] possibleTargets = new GameObject[GameObject.FindGameObjectsWithTag("Player").Length];
        List<GameObject> possibleTargets = new List<GameObject>();

        int nbTargets = 0;
        foreach (GameObject ob in players)
        {
            
            if ((Vector2.Distance(ob.GetComponent<MouvementPersonnage>().getPosPlayer(), actualPosition) <= GetComponent<Ennemy>().getRange() + GetComponent<Ennemy>().getPMEnemyMax()))
            {
                possibleTargets.Add(ob);
                nbTargets++;
            }
        }
        return possibleTargets;
    }

    public GameObject closestTarget(Vector2 actualPosition)
    {
        List<GameObject> whoCanIAttackResult = whoCanIAttack(actualPosition);
        GameObject closestPlayer = whoCanIAttackResult[0];
        foreach(GameObject ob in whoCanIAttackResult)
        {
            Debug.Log("ob.GetComponent<MouvementPersonnage>().getPosPlayer() : " + ob.GetComponent<MouvementPersonnage>().getPosPlayer());
            Debug.Log("closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer() : " + closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer());
            if ((Vector2.Distance(ob.GetComponent<MouvementPersonnage>().getPosPlayer(), actualPosition) > Vector2.Distance(closestPlayer.GetComponent<MouvementPersonnage>().getPosPlayer(), actualPosition)))
            {
                closestPlayer = ob;
            }
        }
        return closestPlayer;
    }

    public bool isThereAPlayerToAttack(Vector2 actualPosition)
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject ob in ennemies)
        {
            if ((Vector2.Distance(ob.GetComponent<MouvementPersonnage>().getPosPlayer(), actualPosition) <= GetComponent<Ennemy>().getRange() + GetComponent<Ennemy>().getPMEnemyMax()))
            {
                return true;
            }
        }
        return false;
    }
}
