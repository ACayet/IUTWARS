using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : Character
{

    public int HPEnemy;
    public int AttackEnemy;
    public int DefenseEnemy;
    public int portéeEnemy;
    Vector3 EnemyPosition;
    public int PAEnemy;
    public int PAEnemyMax;
    float speedEnemy = 2.0f;

    // Use this for initialization
    void Start()
    {
        EnemyPosition = transform.position;
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
            transform.position = Vector3.MoveTowards(transform.position, EnemyPosition, Time.deltaTime * speedEnemy);

            //Destroy(this);

        }
    }

    public void getDamaged(int AttackerAttack)
    {
        HPEnemy = HPEnemy - (AttackerAttack - DefenseEnemy);
    }

    public Vector3 getPos()
    {
        return EnemyPosition;
    }
}
