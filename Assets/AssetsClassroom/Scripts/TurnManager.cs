using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    GameObject[] ennemies = null;
    GameObject[] heroes = null;
    public string turn = "";
    public int nbTurn = 1;

    // Use this for initialization
    void Start () {
        turn = "Player";
        heroes = GameObject.FindGameObjectsWithTag("Player");
        ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
    }
	
	// Update is called once per frame
	void Update () {
        if (!checkStillPlayerTurn() && turn == "Player")
        {
            //Debug.Log("Enemy turn");
            turnChange();
            
                StartCoroutine(DelayEnemyTurn(ennemies));

            
            turnChange();
            nbTurn++;
        }
        
	}

    public void reloadLists()
    {
        GameObject[] h = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] e = GameObject.FindGameObjectsWithTag("Ennemy");
        List<GameObject> addh = new List<GameObject>();
        List<GameObject> adde = new List<GameObject>();
        foreach(GameObject ob in h)
        {
            if(ob.GetComponent<SpriteRenderer>() != null){
                addh.Add(ob);
            }
        }
        foreach (GameObject ob in e)
        {
            if (ob.GetComponent<SpriteRenderer>() != null)
            {
                adde.Add(ob);
            }
        }
        GameObject[] h1 = new GameObject[addh.Count];
        GameObject[] e1 = new GameObject[adde.Count];
        int cpt = 0;
        foreach (GameObject ob in addh)
        {
            h1[cpt] = ob;
            cpt++;
        }
        cpt = 0;
        foreach(GameObject ob in adde)
        {
            e1[cpt] = ob;
            cpt++;
        }
        heroes = h1;
        ennemies = e1;
    }

    private IEnumerator DelayEnemyTurn(GameObject[] Enemy)
    {
        
        foreach(GameObject ob in Enemy)
        {
            //ob.GetComponent<EnemyTurn>().AttackTime();
            ob.GetComponent<EnemyTurn>().newMoveFunction();
            yield return new WaitForSeconds(2f);
        }
    }

    bool checkStillPlayerTurn()
    {
        foreach (GameObject ob in heroes)
        {
            
            if ((ob.GetComponent<CombatJoueur>().getPAPlayer() != 0) && (ob.GetComponent<MouvementPersonnage>().getPM() != -1))
            {
                //Debug.Log("Player still have Action Points left");
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
          //  cutCharacterSelect();
            refreshEnnemies();
        }
        if(turn == "Enemy")
        {
            turn = "Player";
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
