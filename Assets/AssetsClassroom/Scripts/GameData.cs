using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[System.Serializable]
[Serializable]
public class GameData {


    public int HPPlayer;
    public int AttackPlayer;
    public int DefensePlayer;
    public int portéePlayer;
    public int PMPlayer;
    public int PAPlayer;
    public string CurentScene;
    public string PreviousScene;

    public GameData()
    {
        HPPlayer = 100;
        AttackPlayer = 5;
        DefensePlayer = 0;
        portéePlayer = 1;
        PMPlayer = 10;
        PAPlayer = 3;
        CurentScene = "";
        PreviousScene = "";
    }
}
