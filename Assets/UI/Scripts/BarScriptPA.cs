using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarScriptPA : MonoBehaviour {



    [SerializeField]
    private float maxPA; //Fill minimal visuel
    [SerializeField]
    private float PA; //Fill minimal visuel
    [SerializeField]
    private float minFill; //Fill minimal visuel
    [SerializeField]
    [Range(0, 1)]
    private float fillAmount; // pourcentage de PV
    [SerializeField]
    private Image content;
    [SerializeField]
    [Range(0, 1)]
    private float pourcentage;
    [SerializeField]
    private Text LabelPA;

    // Use this for initialization
    void Start()
    {
        pourcentage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        handleBar();
        LabelPA.text = (PA + "/" + maxPA + " PA");
    }
    private void handleBar()
    {

        pourcentage = PA / maxPA; //pourcentage des pm
        //Debug.Log(pourcentage);
        fillAmount = pourcentage * (1 - minFill) + minFill; //
        content.fillAmount = fillAmount;
    }

    private void Map()
    {

    }

}