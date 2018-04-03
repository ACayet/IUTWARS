using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour {

    public GameObject prefab;
    private GameData data;
    private bool FirstLoad;


    // Use this for initialization
    void Start () {
        FirstLoad = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (data.PreviousScene == "MainMenu" && FirstLoad == true)
        {
            Instantiate(prefab, GameObject.Find("StartPoint").transform.position, Quaternion.identity);
            FirstLoad = false;
        }
    }
}
