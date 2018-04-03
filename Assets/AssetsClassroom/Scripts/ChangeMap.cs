using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMap : MonoBehaviour
{

    public string SceneNameToLoad;

    private DataController dataC;

    private void Start()
    {
        dataC = new DataController();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneNameToLoad);
            dataC.SaveGameData(SceneNameToLoad);
            
        }
    }


}