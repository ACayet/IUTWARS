using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changementMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger is on");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("I am here ");
            SceneManager.LoadScene("Couloir_Carte");
        }
    }

}
