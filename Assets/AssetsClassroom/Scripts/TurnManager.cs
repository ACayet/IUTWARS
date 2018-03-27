﻿using System.Collections;
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
        if (checkStillEnemyTurn())
        {
            Debug.Log("Patientez");

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

    bool checkStillEnemyTurn()
    {
        foreach (GameObject ob in ennemies)
        {

            if (ob.GetComponent<Ennemy>().getPAEnemy() != 0)
            {
                Debug.Log("Enemy still have Action Points left");
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
            cutCharacterSelect();
            refreshEnnemies();
        }
        if(turn == "Enemy")
        {
            turn = "Player";
            GetComponent<ClickManager>().changeSelected(heroes[0]);
            refreshHeroes();

        }
    }

    void cutCharacterSelect()
    {
        foreach (GameObject ob in heroes)
        {
            ob.GetComponent<MouvementPersonnage>().setSelected(false);
        }
    }

    void refreshHeroes()
    {
        foreach(GameObject obj in heroes){
            obj.GetComponent<CombatJoueur>().setPAPlayertotheMax();
            obj.GetComponent<MouvementPersonnage>().setPMtotheMax();
        }
    }

    void refreshEnnemies()
    {
        foreach (GameObject obj in ennemies)
        {
            obj.GetComponent<Ennemy>().setPAEnemytotheMax();
            obj.GetComponent<Ennemy>().setPMEnemytotheMax();
        }
    }

}