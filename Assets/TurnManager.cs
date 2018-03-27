using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    GameObject[] ennemies = null;
    GameObject[] heroes = null;
    string turn = "";

    // Use this for initialization
    void Start () {
        turn = "Player";
        heroes = GameObject.FindGameObjectsWithTag("Player");
        ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
    }
	
	// Update is called once per frame
	void Update () {
        if (!checkStillPlayerTurn())
        {
            Debug.Log("Enemy turn");
            turnChange();
        }
	}

    bool checkStillPlayerTurn()
    {
        foreach (GameObject ob in heroes)
        {
            
            if (ob.GetComponent<CombatJoueur>().getPAPlayer() != 0)
            {
                Debug.Log("Player still have Action Points left");
                return true;
            }
        }
        return false;
    }
   
    public string getTurn()
    {
        return turn;
    }

    void turnChange()
    {
        if(turn == "Player")
        {
            turn = "Enemy";
        }
        if(turn == "Enemy")
        {
            turn = "Player";
        }
    }
}
