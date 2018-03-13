using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarScriptPM : MonoBehaviour
{


    [SerializeField]
    private float maxPM; //Fill minimal visuel
    [SerializeField]
    private float PM; //Fill minimal visuel
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
    private Text LabelPM;
    // Use this for initialization
    void Start()
    {
        pourcentage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        handleBar();
        LabelPM.text = (PM + "/" + maxPM + " PM");
    }
    private void handleBar()
    {

        pourcentage = PM / maxPM; //pourcentage des pm
        //Debug.Log(pourcentage);
        fillAmount = pourcentage * (1 - minFill) + minFill; //
        content.fillAmount = fillAmount;
    }

    private void Map()
    {

    }

}
