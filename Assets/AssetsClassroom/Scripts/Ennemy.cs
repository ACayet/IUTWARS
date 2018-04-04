using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : Character
{

    public int HPEnemy;
    public int HPEnemyMax;
    public int AttackEnemy;
    public int DefenseEnemy;
    public int portéeEnemy;
    public Vector3 EnemyPosition;
    public int PAEnemy;
    public int PAEnemyMax;
    public int PMEnemy;
    public int PMEnemyMax;
    float speedEnemy = 2.0f;
    public string enemyName;

    // Use this for initialization
    void Start()
    {
        EnemyPosition = transform.position;
        setPAEnemytotheMax();
        setPMEnemytotheMax();
        setHPEnemytotheMax();
    }

    private void setHPEnemytotheMax()
    {
        HPEnemy = HPEnemyMax;
    }

    public int getPMEnemy()
    {
        return PMEnemy;
    }

    public void reducePM()
    {
        PMEnemy = PMEnemy - 1;
    }

    public void reducePA()
    {
        PAEnemy = PAEnemy - 1;
    }


    public int getPAEnemy()
    {
        return PAEnemy;
    }

    public int getPMEnemyMax()
    {
        return PMEnemyMax;
    }

    public int getRange()
    {
        return portéeEnemy;
    }

    public void modifPos(Vector3 vectorAdd)
    {
        EnemyPosition = EnemyPosition + vectorAdd;
    }

    internal int getAttackEnemy()
    {
        return AttackEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        if (HPEnemy <= 0)
        {
            speedEnemy = 100.0f;
            EnemyPosition += 100 * Vector3.up;
            //GetComponent<Animator>().SetTrigger("StandDown");
            GetComponent<Animator>().SetTrigger("WalkDown");
            Destroy(GetComponent<SpriteRenderer>());
            transform.position = Vector3.MoveTowards(transform.position, EnemyPosition, Time.deltaTime * speedEnemy);
            GameObject.FindGameObjectWithTag("FightManager").GetComponent<TurnManager>().reloadLists();
            Destroy(gameObject);
            
        }
    }

    internal float getSpeed()
    {
        return speedEnemy;
    }

    public void getDamaged(int AttackerAttack)
    {
        HPEnemy = HPEnemy - (AttackerAttack - DefenseEnemy);
        Debug.Log(enemyName + " a perdu " + (AttackerAttack - DefenseEnemy) + " Points de vie");
    }

    public Vector3 getPos()
    {
        return EnemyPosition;
    }

    internal void setPAEnemytotheMax()
    {
        PAEnemy = PAEnemyMax;
    }

    internal void setPMEnemytotheMax()
    {
        PMEnemy = PMEnemyMax;
    }
}
