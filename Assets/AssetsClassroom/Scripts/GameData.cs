using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData {

    MouvementPersonnage character = new MouvementPersonnage();

    Vector3 posPlayer;                                // For movement
    float speedPlayer;                         // Speed of movement
    int HPPlayer;
    int AttackPlayer;
    int DefensePlayer;
    int portéePlayer;
    int PMPlayer;
    int PAPlayer;
    bool isSelected;

    // Use this for initialization
    void Start()
    {
        posPlayer = character.getPosPlayer(); // Take the initial position
        speedPlayer = 2.0f;                         // Speed of movement
        HPPlayer = 100;
        AttackPlayer = 10;
        DefensePlayer = 0;
        portéePlayer = 2;
        PMPlayer = 3;
        PAPlayer = 2;
        isSelected = false;
    }

}
