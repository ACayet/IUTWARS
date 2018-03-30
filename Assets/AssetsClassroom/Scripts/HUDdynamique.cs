using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDdynamique : MonoBehaviour {

    private GameObject Vie;
    private GameData playerData;

    // Use this for initialization
    void Start () {
        playerData = new GameData();
        //Vie.GetComponent<Image>().fillAmount = playerData.HPPlayer;
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Image>().fillAmount = playerData.HPPlayer;
	}
}
