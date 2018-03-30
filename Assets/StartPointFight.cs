using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointFight : MonoBehaviour
{

    private GameObject[] ThePlayer;
    private CameraControler TheCamera;

    // Use this for initialization
    void Start()
    {

        ThePlayer = GameObject.FindGameObjectsWithTag("Player");
        ThePlayer[0].transform.position = transform.position;

        /*TheCamera = FindObjectOfType<CameraControler>();
        TheCamera.transform.position = new Vector3(transform.position.x, transform.position.y, TheCamera.transform.position.z);*/


    }

    // Update is called once per frame
    void Update()
    {

    }
}