﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{

    GameObject currentClicked = null;
    GameObject[] ennemies = null;
    GameObject[] heroes = null;
    GameObject currentHero = null;

    // Use this for initialization
    void Start()
    {
        heroes = GameObject.FindGameObjectsWithTag("Player");
        ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
        changeSelected(heroes[0]);
    }

    // Update is called once per frame
    void Update()
    {
        currentHero.GetComponent<CombatJoueur>().getPositionOfPlayer(currentHero.GetComponent<MouvementPersonnage>().getPosPlayer());
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            Debug.Log("Mouse Clicked at " + mousePos.x + " " + mousePos.y);
            if (hit.collider != null)
            {
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
                currentClicked = hit.collider.gameObject;
              
                
                if (hit.collider.tag == "Ennemy")
                {
                    /* if (GetComponent<TurnManager>().getTurn() == "Player")
                     {
                         currentHero.GetComponent<CombatJoueur>().AttackTarget(currentClicked);
                     }*/
                    currentHero.GetComponent<CombatJoueur>().AttackTarget(currentClicked);
                }
                if (hit.collider.tag == "Player")
                {
                    changeSelected(hit.collider.gameObject);
                }
            }
        }
    }

    public void changeSelected(GameObject Hero)
    {
        foreach (GameObject ob in heroes)
        {
            ob.GetComponent<MouvementPersonnage>().setSelected(false);
        }
        Hero.GetComponent<MouvementPersonnage>().setSelected(true);
        currentHero = Hero;
    }

    
}
