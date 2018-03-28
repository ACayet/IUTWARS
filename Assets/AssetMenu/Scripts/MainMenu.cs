using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    DataController dataC = new DataController();
    GameData loadData;
    public string Scene_to_load;

    public void PlayNewGame()
    {
        dataC.SaveGameData(Scene_to_load);
        SceneManager.LoadScene(Scene_to_load);
    }

    public void ContinuGame()
    {
        loadData = dataC.LoadGameData();
        SceneManager.LoadScene(loadData.CurentScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
