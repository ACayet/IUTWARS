using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarScriptPV : MonoBehaviour {


    [SerializeField]
    private float maxPV; //Fill minimal visuel
    [SerializeField]
    private float PV; //Fill minimal visuel
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
    [Range(0, 1)]
    private float colorR;
    [SerializeField]
    [Range(0, 1)]
    private float colorV;
    [SerializeField]
    private Text LabelPV;
    // Use this for initialization
    void Start()
    {
        pourcentage = 0;
    }

    // Update is called once per frame
    void Update() {
        handleBar();
        LabelPV.text = (PV + "/" + maxPV + " PV");
    }
    private void handleBar()
    {
        
        pourcentage = PV / maxPV; //pourcentage des pvs
        Debug.Log(pourcentage);
       fillAmount = pourcentage*(1-minFill)+minFill; //
        
        if (pourcentage > 0.5)
        {
            colorV = 1;
            colorR = (float)(1 - ((pourcentage-0.5)*2));
        }
        else if (pourcentage < 0.5)
        {
            colorR = 1;
            colorV = (pourcentage * 2);
        }
        else if (pourcentage == 0.5)
        {
            colorR = 1;
            colorV = 1;
        }

        content.color = new Color(colorR, colorV,0,1);
        content.fillAmount = fillAmount;
    }

    private void Map()
    {
       
    }

}
