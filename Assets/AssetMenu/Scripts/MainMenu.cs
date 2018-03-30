using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    DataController dataC;
    GameData loadData;
    public string Scene_to_load;

    private void Start()
    {
        dataC = new DataController();
    }

    public void PlayNewGame()
    {
        dataC.SaveGameData(Scene_to_load);
        SceneManager.LoadScene(Scene_to_load);
    }

    public void ContinuGame()
    {
        loadData = dataC.LoadGameData();
        SceneManager.LoadScene(loadData.CurentScene);
        GameObject instance = Instantiate(Resources.Load("Personnage", typeof(GameObject))) as GameObject;
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
