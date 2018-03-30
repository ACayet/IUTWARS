using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour {

    public float CoordX;
    public float CoordY;
    public GameObject reference;

	// Use this for initialization
	void Start () {
        reference = null;
	}
	
	// Update is called once per frame
	void Update () {
        reference = isThereSomeoneHere();
	}

    public void setCoordX(float x)
    {
        CoordX = x; 
    }

    public void setCoordY(float y)
    {
        CoordY = y;
    }

    public float getCoordY()
    {
        return CoordY;
    }

    public float getCoordX()
    {
        return CoordX;
    }

    public GameObject getReference()
    {
        return reference;
    }

    GameObject isThereSomeoneHere()
    {
        Vector3 here = new Vector3 (CoordX, CoordY, 0.0f);
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
        foreach(GameObject ob in heroes)
        {
            if((here - new Vector3(0.0f, 0.5f, 0.0f)) == ob.GetComponent<MouvementPersonnage>().getPosPlayer())
            {
                Debug.Log("Found a player at " + CoordX + " " + CoordY);
                return ob;
            }

        }
        foreach (GameObject ob in ennemies)
        {
            if (here - new Vector3(0.0f, 0.5f, 0.0f) == ob.GetComponent<Ennemy>().getPos())
            {
                Debug.Log("Found a target at " + CoordX + " " + CoordY);
                return ob;
            }

        }
        return null;
    }
}
