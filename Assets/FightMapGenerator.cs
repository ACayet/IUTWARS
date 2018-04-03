using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMapGenerator : MonoBehaviour {

    public Sprite[] sprites;
    public GameObject[] Cases;

    // Use this for initialization
    void Start () {
        
        level1();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void level1()
    {
        for (int y = -5; y < 5; y++) {
            for (int x = -5; x < 5; x++) {

                GameObject CaseXY = new GameObject();
                CaseXY.AddComponent<Case>();
                CaseXY.GetComponent<Case>().setCoordX(x + 0.5f);
                CaseXY.GetComponent<Case>().setCoordY(y + 0.5f);
                CaseXY.transform.position = new Vector3(x + 0.5f, y + 0.5f, 0);
                CaseXY.AddComponent<SpriteRenderer>().sprite = sprites[0];
                
                CaseXY.tag = "WalkableCase";

            }
        }
        Cases = GameObject.FindGameObjectsWithTag("WalkableCase");

    }

    public bool canWalk(Vector3 dpl)
    {
        GameObject caseToWalk = getCase(dpl);
        if(caseToWalk == null)
        {
            //Debug.Log("There's nothing here");
            return false;
        }
        if (caseToWalk.GetComponent<Case>().getReference() == null)
        {
           // Debug.Log("It's empty");
            return true;
        }
        
        else Debug.Log("There's someone here"); return false;
    }

    public GameObject getCase(Vector3 dpl)
    {
        foreach(GameObject ob in Cases)
        {
            //Debug.Log("Checking if a case exist at " + ob.GetComponent<Case>().getCoordX() + " " + ob.GetComponent<Case>().getCoordY());
            if(dpl == new Vector3(ob.GetComponent<Case>().getCoordX(), ob.GetComponent<Case>().getCoordY() - 0.5f, 0.0f))
            {
               // Debug.Log("It's here");
                return ob;
            }
        }
        return null;
    }

    public GameObject getCase(float x, float y)
    {
        foreach(GameObject ob in Cases)
        {
            if(ob.GetComponent<Case>().getCoordX() == x && ob.GetComponent<Case>().getCoordY() == y)
            {
                return ob;
            }
        }
        return null;
    }

    public GameObject[] getCases()
    {
        return Cases;
    }
}
