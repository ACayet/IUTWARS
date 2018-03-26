using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

    GameObject currentClicked = null;
    GameObject[] ennemies = null;
    GameObject[] heroes = null;
    GameObject currentHero = null;

	// Use this for initialization
	void Start () {
		heroes = GameObject.FindGameObjectsWithTag("Player");
        ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
        changeSelected(heroes[0]);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            Debug.Log("Mouse Clicked at " + mousePos.x + " " + mousePos.y);
            if (hit.collider != null)
            {
                Debug.Log("Something with the tag " + hit.collider.tag + " was clicked! at " + mousePos.x + " " + mousePos.y);
                hit.collider.attachedRigidbody.AddForce(Vector2.up);
                currentClicked = hit.collider.gameObject;
                Debug.Log(currentClicked.tag);
                //currentClicked.GetComponent<Ennemy>().getDamaged(currentHero.GetComponent<MouvementPersonnage>().getAttack());
                if (hit.collider.tag == "Ennemy")
                {
                    currentHero.GetComponent<MouvementPersonnage>().AttackTarget(currentClicked);
                }
                if (hit.collider.tag == "Player")
                {
                    changeSelected(hit.collider.gameObject);
                }
            }
        }
    }

    void changeSelected(GameObject Hero)
    {
        foreach(GameObject ob in heroes)
        {
            ob.GetComponent<MouvementPersonnage>().setSelected(false);
        }
        Hero.GetComponent<MouvementPersonnage>().setSelected(true);
        currentHero = Hero;
    }
}
