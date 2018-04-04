using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(GameObject.FindGameObjectWithTag("PlayerMap") != null)
        {
            GameObject.FindGameObjectWithTag("PlayerMap").GetComponent<MouvementPersonnage>().getOutOfScene();

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
